using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Darcy_Backup
{
    public partial class Form_Darcy_Panel
    {

        private bool _cancel = false;


        private string[] AddToStringArray(string[] array, string[] addArray)
        {
            string[] newArray = new string[array.Length + addArray.Length];

            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            for (int i = 0; i < addArray.Length; i++)
                newArray[array.Length + i] = addArray[i];

            return newArray;
        }
        
        private bool Different(string path1, string path2, bool hash, out string error)
        {
            error = "";
            if (File.Exists(path2) == false)
                return true;
            

            long length1 = new System.IO.FileInfo(path1).Length;
            long length2 = new System.IO.FileInfo(path2).Length;

            if (length1 != length2)
                return true;

            DateTime time1 = new System.IO.FileInfo(path1).LastWriteTime;
            DateTime time2 = new System.IO.FileInfo(path2).LastWriteTime;

            if (time1 != time2)
                return true;

            
            //Setting in new/edit entry
            if (hash == false)
                return false;


            byte[] buffer;
            byte[] oldBuffer;
            int bytesRead;
            int oldBytesRead;
            long size;
            long totalBytesRead = 0;


            string checksum1 = "", checksum2 = "";
            
            for (int i = 0; i < 2; i++)
            {
                string path = path1;
                if (i == 1)
                    path = path2;
                using (Stream stream = File.OpenRead(path))
                using (HashAlgorithm hashAlgorithm = MD5.Create())
                {
                    size = stream.Length;

                    buffer = new byte[4096];
                    try
                    {
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                    }
                    catch (IOException e)
                    {
                        error = e.ToString();
                        return false;
                    }
                    catch (NotSupportedException e)
                    {

                        error = e.ToString();
                        return false;
                    }
                    catch (ObjectDisposedException e)
                    {

                        error = e.ToString();
                        return false;
                    }
                    totalBytesRead += bytesRead;

                    do
                    {
                        if (_cancel)
                            return true;

                        oldBytesRead = bytesRead;
                        oldBuffer = buffer;

                        buffer = new byte[4096];
                        bytesRead = stream.Read(buffer, 0, buffer.Length);
                        totalBytesRead += bytesRead;
                        if (bytesRead == 0)
                        {
                            hashAlgorithm.TransformFinalBlock(oldBuffer, 0, oldBytesRead);
                        }
                        else
                        {
                            hashAlgorithm.TransformBlock(oldBuffer, 0, oldBytesRead, oldBuffer, 0);
                        }
                    } while (bytesRead != 0);

                    if (i == 0)
                        checksum1 = hashAlgorithm.Hash.ToString();
                    else
                        checksum2 = hashAlgorithm.Hash.ToString();
                }
            }
            
            if (checksum1 == checksum2)
                return false;

            return true;
        }

        private int IndexOfEntry(int entry)
        {

            for (int i = 0; i < Entries.Length; i ++)
            {
                if (Entries[i].Entry == entry)
                    return i;
            }

            return -1;
        }

        class CopyClass
        {
            public class ItemsClass
            {
                public string Source { get; set; }
                public string Destination { get; set; }
            };

            public ItemsClass[] Items { get; set; }

            public CopyClass()
            {
                Items = new ItemsClass[0];
            }

            public void AddItem(string source, string destination)
            {
                int count = Items.Count();
                ItemsClass[] add = new ItemsClass[count + 1];

                for (int i = 0; i < Items.Count(); i++)
                    add[i] = Items[i];

                add[count] = new ItemsClass();
                add[count].Source = source;
                add[count].Destination = destination;

                Items = add;
            }
        }

        delegate void EnableCancelCallback(bool b);
        private void EnableCancel(bool b)
        {
            if (List_Backup.InvokeRequired == true)
            {
                EnableCancelCallback d = new EnableCancelCallback(EnableCancel);
                this.Invoke(d, new object[] { b });
            }
            else
            {
                Button_Cancel.Enabled = b;
            }
        }

        private void Perform(int entry)
        {
            _cancel = false;
            DateTime startTime = DateTime.Now;
            Entries[entry].Status = "Processing";
            UpdateListItem(Entries[entry], entry);

            if (_currentListSel == entry)
                EnableCancel(true);

            int copyCount = 0;
            int noDiffCount = 0;

            string source = Entries[entry].Source;
            bool file = false;
            bool directory = false;


            CopyClass copy = new CopyClass();


            file = File.Exists(source);
            directory = Directory.Exists(source);
            if (file == false)
            {
                if (directory == false)
                {
                    AddToLog(entry, "Source not found", "Could not find " + source);
                    return;
                }
            }
            if (Directory.Exists(Entries[entry].Destination) == false)
            {
                try
                {
                    System.IO.Directory.CreateDirectory(Entries[entry].Destination);
                }
                catch (System.IO.DirectoryNotFoundException)
                {
                    AddToLog(entry, "Destination not found", "Could not find " + Entries[entry].Destination);
                    return;
                }
                catch (System.NotSupportedException)
                {
                    AddToLog(entry, "Illegal destination", "Illegal destination: " + Entries[entry].Destination);
                    return;
                }
            }
            
            string mode = ModeToString(Entries[entry].Mode);

            if (file)
            {
                string[] strArray = source.Split('\\');
                string filename = strArray[strArray.Length - 1];
                string destination = Entries[entry].Destination; 


                
                if (mode == "Changed Files")
                {

                    Entries[entry].Status = "Comparing";
                    UpdateListItem(Entries[entry], entry);

                    string[] split = destination.Split('\\');
                    if (split[split.Length - 1] == "")
                        destination = destination.Remove(destination.Length - 1, 1);

                    string hashError;
                    bool different = Different(source, destination + "\\" + filename, Entries[entry].Hash, out hashError);
                    if (hashError != "")
                    {
                        AddToLog(entry, "Hash Error", hashError);
                        return;
                    }
                    if (different)
                    {
                        try
                        {
                            //System.IO.File.Copy(source, destination + "\\" + filename, true);
                            copyCount++;
                            copy.AddItem(source, destination + "\\" + filename);
                        }
                        catch (IOException error)
                        {
                            AddToLog(entry, "IO Exception", error.Message);
                            return;
                        }

                    }
                    else
                        noDiffCount++;
                }
                else if (mode == "New Copies")
                {
                    string[] split = destination.Split('\\');
                    if (split[split.Length - 1] == "")
                        destination = destination.Remove(destination.Length - 1, 1);
                    try
                    {
                        strArray = filename.Split('.');
                        string extension = strArray[strArray.Length - 1];


                        string tempString = strArray[0];
                        for (int i = 1; i < strArray.Length-1; i++)
                            tempString += "." + strArray[i];
                        filename = tempString;


                        String timestring = DateTime.Now.ToString(" (yyyyMMdd-HH.mm)");
                        string fullDest = destination + "\\" + filename + timestring + '.' + extension;
                        //System.IO.File.Copy(source, fullDest, true);
                        copyCount++;
                        copy.AddItem(source, fullDest);
                    }
                    catch (IOException error)
                    {
                        AddToLog(entry, "IO Exception", error.Message);
                        return;
                    }

                }
                else if (mode == "Replace files")
                {
                    string[] split = destination.Split('\\');
                    if (split[split.Length - 1] == "")
                        destination = destination.Remove(destination.Length - 1, 1);
                    try
                    {
                        //System.IO.File.Copy(source, destination + filename, true);
                        copyCount++;
                        copy.AddItem(source, destination + "\\" + filename);
                    }
                    catch (IOException error)
                    {
                        AddToLog(entry, "IO Exception", error.Message);
                        return;
                    }
                }
            }
            else if (directory)
            {
                string[] folders = new string[1];
                folders[0] = source;

                string[] subFolders = System.IO.Directory.GetDirectories(source, "*", System.IO.SearchOption.AllDirectories);

                folders = AddToStringArray(folders, subFolders);
                
                string[] files = System.IO.Directory.GetFiles(source);
                string destination = Entries[entry].Destination;

                if (mode == "Changed Files")
                {
                    Entries[entry].Status = "Comparing";
                    UpdateListItem(Entries[entry], entry);

                    string[] split = destination.Split('\\');
                    if (split[split.Length - 1] == "")
                        destination = destination.Remove(destination.Length - 1, 1);

                    for (int i = 0; i < folders.Length; i++)
                    {
                        string destAdd = folders[i].Remove(0, folders[0].Length);
                        if (System.IO.Directory.Exists(Entries[entry].Destination + destAdd) == false)
                        {
                            try
                            {
                                System.IO.Directory.CreateDirectory(Entries[entry].Destination + destAdd);
                            }
                            catch (System.IO.DirectoryNotFoundException)
                            {
                                AddToLog(entry, "Destination not found", "Could not find " + Entries[entry].Destination + destAdd);
                                return;
                            }
                            catch (System.NotSupportedException)
                            {
                                AddToLog(entry, "Illegal destination", "Illegal destination: " + Entries[entry].Destination + destAdd);
                                return;
                            }
                        }
                        

                        files = System.IO.Directory.GetFiles(folders[i]);

                        foreach (string s in files)
                        {

                            if (_cancel == true)
                            {
                                AddToLog(entry, "Abort", "Aborted by user");
                                if (_currentListSel == entry)
                                    EnableCancel(false);
                                return;
                            }

                            string fileName = System.IO.Path.GetFileName(s);
                            string destFile = System.IO.Path.Combine(destination + destAdd + "\\", fileName);

                            string hashError;
                            bool different = Different(source + destAdd + "\\" + fileName, destFile, Entries[entry].Hash, out hashError);
                            if (hashError != "")
                            {
                                AddToLog(entry, "Hash Error", hashError);
                                return;
                            }
                            if (different)
                            {
                                try
                                {
                                    //System.IO.File.Copy(s, destFile, true);
                                    copyCount++;
                                    copy.AddItem(s, destFile);
                                }
                                catch (IOException error)
                                {
                                    AddToLog(entry, "IO Exception", error.Message);
                                    return;
                                }
                            }
                            else
                                noDiffCount++;
                        }
                    }
                }
                else if (mode == "New Copies")
                {
                    string[] split = destination.Split('\\');
                    if (split[split.Length - 1] == "")
                        destination = destination.Remove(destination.Length - 1, 1);

                    destination += DateTime.Now.ToString(" (yyyy-MM-dd HH.mm)");
                    try
                    {
                        System.IO.Directory.CreateDirectory(destination);
                    }
                    catch (System.IO.DirectoryNotFoundException)
                    {
                        AddToLog(entry, "Destination not found", "Could not find " + destination);
                        return;
                    }
                    catch (System.NotSupportedException)
                    {
                        AddToLog(entry, "Illegal destination", "Illegal destination, " + Entries[entry].Destination);
                        return;
                    }


                    foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
                    {
                        try
                        {
                            Directory.CreateDirectory(dirPath.Replace(source, destination));
                        }
                        catch (System.IO.DirectoryNotFoundException)
                        {
                            AddToLog(entry, "Destination not found", "Could not find" + destination);
                            return;
                        }
                        catch (System.NotSupportedException)
                        {
                            AddToLog(entry, "Illegal destination", "Illegal destination: " + Entries[entry].Destination);
                            return;
                        }
                    }

                    foreach (string newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
                    {
                        try
                        {
                            //File.Copy(newPath, newPath.Replace(source, destination), true);
                            copyCount++;
                            copy.AddItem(newPath, newPath.Replace(source, destination));

                        }
                        catch (IOException error)
                        {
                            AddToLog(entry, "IO Exception", error.Message);
                            return;
                        }
                    }
                }
                else if (mode == "Replace Files")
                {
                    if (System.IO.Directory.Exists(Entries[entry].Destination) == false)
                    {
                        try
                        {
                            System.IO.Directory.CreateDirectory(Entries[entry].Destination); 
                        }
                        catch (System.IO.DirectoryNotFoundException)
                        {
                            AddToLog(entry, "Destination not found", "Could not find " + Entries[entry].Destination);
                            return;
                        }
                        catch (System.NotSupportedException)
                        {
                            AddToLog(entry, "Illegal destination", "Illegal destination: " + Entries[entry].Destination);
                            return;
                        }
                    }



                    foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
                    {
                        try
                        {
                            Directory.CreateDirectory(dirPath.Replace(source, destination));
                        }
                        catch (System.IO.DirectoryNotFoundException)
                        {
                            AddToLog(entry, "Destination not found", "Could not find " + destination);
                            return;
                        }
                        catch (System.NotSupportedException)
                        {
                            AddToLog(entry, "Illegal destination", "Illegal destination: " + Entries[entry].Destination);
                            return;
                        }
                    }

                    foreach (string newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
                    {
                        try
                        {
                            //File.Copy(newPath, newPath.Replace(source, destination), true);
                            copyCount++;
                            copy.AddItem(newPath, newPath.Replace(source, destination));
                        }
                        catch (IOException error)
                        {
                            AddToLog(entry, "IO Exception", error.Message);
                            return;
                        }
                    }
                }
            }

            int failCount = 0;

            if (_cancel == true)
            {
                AddToLog(entry, "Abort", "Aborted by user");
                if (_currentListSel == entry)
                    EnableCancel(false);
                return;
            }

            if (copy.Items.Count() != 0)
            {
                byte[] buffer = new byte[1024 * 1024];

                long totalSize = 0;
                long totalBytes = 0;
                for (int i = 0; i < copy.Items.Count(); i ++)
                {
                    using (FileStream sc = new FileStream(copy.Items[i].Source, FileMode.Open, FileAccess.Read))
                    {
                        totalSize += sc.Length;
                    }
                }
                double lastPercentage = 0;
                for (int i = 0; i < copy.Items.Count(); i ++)
                {
                    using (FileStream sc = new FileStream(copy.Items[i].Source, FileMode.Open, FileAccess.Read))
                    {
                        if (File.Exists(copy.Items[i].Destination) == true)
                        {
                            try
                            {
                                File.Delete(copy.Items[i].Destination);
                            }
                            catch (DirectoryNotFoundException error)
                            {
                                AddToLog(entry, "Directory not found", "Replace File\n\n" + error.Message);
                                return;
                            }
                            catch (IOException error)
                            {
                                AddToLog(entry, "IO Exception", "Replace File\n\n" + error.Message);
                                return;
                            }
                            catch (UnauthorizedAccessException error)
                            {
                                AddToLog(entry, "No Access", "Replace File\n\n" + error.Message);
                                return;
                            }
                            catch (NotSupportedException error)
                            {
                                AddToLog(entry, "Not Supported", "Replace File\n\n" + error.Message);
                                return;
                            }
                        }
                        using (FileStream dest = new FileStream(copy.Items[i].Destination, FileMode.CreateNew, FileAccess.Write))
                        {
                            int currentBlockSize = 0;

                            while ((currentBlockSize = sc.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                if (_cancel == true)
                                {
                                    AddToLog(entry, "Abort", "Aborted by user");
                                    if (_currentListSel == entry)
                                        EnableCancel(false);
                                    return;
                                }

                                totalBytes += currentBlockSize;
                                double percentage = (double)totalBytes * 100.0 / totalSize;

                                if (percentage - lastPercentage > 0.1)
                                {
                                    lastPercentage = percentage;
                                    Entries[entry].Status = lastPercentage.ToString("0.0") + "%";
                                    UpdateListItem(Entries[entry], entry);
                                }

                                try
                                {
                                    dest.Write(buffer, 0, currentBlockSize);
                                }
                                catch (IOException error)
                                {
                                    AddToLog(entry, "IO Exception", "Write Buffer\n\n" + error.Message);
                                    failCount++;
                                    break; 
                                }
                                catch (ObjectDisposedException error)
                                {
                                    AddToLog(entry, "Object Disposed", "Write Buffer\n\n" + error.Message);
                                    failCount++;
                                    break; 
                                }
                                catch (NotSupportedException error)
                                {
                                    AddToLog(entry, "Not Supported", "Write Buffer\n\n" + error.Message);
                                    failCount++;
                                    break; 
                                }
                            }
                        }
                    }
                    try
                    {
                        File.SetLastWriteTime(copy.Items[i].Destination, File.GetLastWriteTime(copy.Items[i].Source));
                    }
                    catch (FileNotFoundException error)
                    {
                        AddToLog(entry, "File Not Found", "SetLastWriteTime\n\n" + error.Message);
                        continue;
                    }
                    catch (UnauthorizedAccessException error)
                    {
                        AddToLog(entry, "Unauthorized", "SetLastWriteTime\n\n" + error.Message);
                        continue;
                    }
                    catch (NotSupportedException error)
                    {
                        AddToLog(entry, "Not Supported", "SetLastWriteTime\n\n" + error.Message);
                        continue;
                    }
                }
            }
            

            string tag = "";
            string subject = "Success";

            tag += copyCount;

            if (copyCount == 1)
                tag += " File Copied";
            else
                tag += " Files Copied";

            if (noDiffCount == 1)
                tag += "\n1 File Not Different";
            else if (noDiffCount > 1)
                tag += "\n" + noDiffCount + " Files Not Different";


            if (failCount == 1)
            {
                tag += "\n1 One File Failed";
                if (copyCount == 0 && noDiffCount == 0)
                    subject = "Fail";
                else
                    subject = "Partial Success";
            }
            else if (failCount > 1)
            {
                tag += "\n" + failCount + "Files Failed";
                if (copyCount == 0 && noDiffCount == 0)
                    subject = "Fail";
                else
                    subject = "Partial Success";
            }


            if (_currentListSel == entry)
                EnableCancel(false);
            
            TimeSpan timeDiff = DateTime.Now.Subtract(startTime);

            tag += "\n\nTotal Time: " + (int)timeDiff.TotalSeconds + " Seconds";

            AddToLog(entry, "Success", tag);
        }
    }
}
