using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Darcy_Backup
{
    class Perform
    {
        private Form_Darcy_Panel Main;

        public Perform(Form_Darcy_Panel main)
        {
            Main = main;
        }


        public bool Cancel = false;

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
                        if (Cancel)
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
        
        private bool CreateDirectory(int entry, string dir)
        {
            try
            {
                Directory.CreateDirectory(dir);
                return true;
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                Main.AddToLog(entry, "Destination not found", "Could not find " + dir);
                return false;
            }
            catch (System.NotSupportedException)
            {
                Main.AddToLog(entry, "Illegal destination", "Illegal destination: " + dir);
                return false;
            }
        }

        private void Abort(int entry)
        {
            Main.AddToLog(entry, "Abort", "Aborted by user");
            if (Main.CurrentListSel == entry)
                Main.EnableCancel(false);
            return;
        }


        public void Start(int entry)
        {
            Cancel = false;
            DateTime startTime = DateTime.Now;

            EntryClass[] Entries = Main.Entries;

            Entries[entry].Status = "Processing";
            Main.UpdateListItem(Entries[entry], entry);

            if (Main.CurrentListSel == entry)
                Main.EnableCancel(true);

            int copyCount = 0;
            int noDiffCount = 0;

            string source = Entries[entry].Source;
            string destination = Entries[entry].Destination;
            string mode = Main.ModeToString(Entries[entry].Mode);

            bool file = false;
            bool directory = false;


            CopyClass copy = new CopyClass();


            file = File.Exists(source);
            directory = Directory.Exists(source);
            if (file == false && directory == false)
            {
                Main.AddToLog(entry, "Source not found", "Could not find " + source);
                return;
            }

            //Remove any trailing backslash
            string[] split = destination.Split('\\');
            if (split[split.Length - 1] == "")
                destination = destination.Remove(destination.Length - 1, 1);


            //SOURCE IS A FILE

            if (file)
            {
                string[] strArray = source.Split('\\');
                string filename = strArray[strArray.Length - 1];


                if (mode == "Changed Files")
                {
                    //Added, because md5 on a large file may take a time to compare.
                    Entries[entry].Status = "Comparing";
                    Main.UpdateListItem(Entries[entry], entry);

                    string hashError;
                    bool different = Different(source, destination + "\\" + filename, Entries[entry].Hash, out hashError);
                    if (hashError != "")
                    {
                        Main.AddToLog(entry, "Hash Error", hashError);
                        return;
                    }

                    //Has the file changed? If so, add to copy class
                    if (different)
                    {
                        copyCount++;
                        copy.AddItem(source, destination + "\\" + filename);
                    }
                    else
                        noDiffCount++;
                }
                else if (mode == "New Copies")
                {

                    //Split so that we can add timestamp
                    strArray = filename.Split('.');
                    string extension = strArray[strArray.Length - 1];


                    //Re-add potential string parts, example: c:\example\text.this.file.txt will split up into 4 strings
                    string tempString = strArray[0];
                    for (int i = 1; i < strArray.Length - 1; i++)
                        tempString += "." + strArray[i];
                    filename = tempString;


                    String timestring = DateTime.Now.ToString(" (yyyyMMdd-HH.mm)");
                    string fullDest = destination + "\\" + filename + timestring + '.' + extension;


                    copyCount++;
                    copy.AddItem(source, fullDest);

                }
                else if (mode == "Replace Files")
                {
                    try
                    {
                        //System.IO.File.Copy(source, destination + filename, true);
                        copyCount++;
                        copy.AddItem(source, destination + "\\" + filename);
                    }
                    catch (IOException error)
                    {
                        Main.AddToLog(entry, "IO Exception", error.Message);
                        return;
                    }
                }
            }

            //SOURCE IS A DIRECTORY

            else if (directory)
            {
                //Get all the root and subdirs for the source
                string[] folders = new string[1];
                folders[0] = source;

                string[] subFolders = System.IO.Directory.GetDirectories(source, "*", System.IO.SearchOption.AllDirectories);
                folders = AddToStringArray(folders, subFolders);


                if (mode == "Changed Files")
                {
                    //Added, because md5 on a large file may take a time to compare.
                    Entries[entry].Status = "Comparing";
                    Main.UpdateListItem(Entries[entry], entry);


                    for (int i = 0; i < folders.Length; i++)
                    {
                        //example: folders[i] == c:\example\test, folders[0] == c:\example, destAdd == \test
                        string destAdd = folders[i].Remove(0, folders[0].Length);

                        //Create destination dir if it does not exist, return if unsuccessful
                        if (System.IO.Directory.Exists(destination + "\\" + destAdd) == false)
                            if (CreateDirectory(entry, destination + "\\" + destAdd) == false)
                                return;


                        //Get all files for the dir
                        string[] files = System.IO.Directory.GetFiles(folders[i]);
                        foreach (string s in files)
                        {

                            if (Cancel == true)
                            {
                                Abort(entry);
                                return;
                            }

                            string fileName = System.IO.Path.GetFileName(s);
                            string destFile = System.IO.Path.Combine(destination + "\\" + destAdd + "\\", fileName);

                            string hashError;
                            bool different = Different(source + destAdd + "\\" + fileName, destFile, Entries[entry].Hash, out hashError);
                            if (hashError != "")
                            {
                                Main.AddToLog(entry, "Hash Error", hashError);
                                return;
                            }

                            //Has the file changed? If so, add to copy class
                            if (different)
                            {
                                copyCount++;
                                copy.AddItem(s, destFile);
                            }
                            else
                                noDiffCount++;
                        }
                    }
                }
                else if (mode == "New Copies")
                {

                    //Create destination root directory with timestamp add
                    destination += DateTime.Now.ToString(" (yyyy-MM-dd HH.mm)");
                    if (CreateDirectory(entry, destination) == false)
                        return;

                    //Create all subdirectories - ((Replace) c:\example -> d:\copy)
                    foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
                        if (CreateDirectory(entry, dirPath.Replace(source, destination)) == false)
                            return;

                    //Add all files from all subdirs to the copy class
                    foreach (string newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
                    {
                        copyCount++;
                        copy.AddItem(newPath, newPath.Replace(source, destination));
                    }
                }

                else if (mode == "Replace Files")
                {
                    //Create destination root directory, if it does not exist
                    if (System.IO.Directory.Exists(destination) == false)
                        if (CreateDirectory(entry, destination) == false)
                            return;

                    //Create all subdirectories - ((Replace) c:\example -> d:\copy)
                    foreach (string dirPath in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
                        if (CreateDirectory(entry, dirPath.Replace(source, destination)) == false)
                            return;

                    //Add all files from all subdirs to the copy class
                    foreach (string newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
                    {
                        copyCount++;
                        copy.AddItem(newPath, newPath.Replace(source, destination));
                    }
                }
            }

            //Quite unlikely that this will ever trigger, but wth
            if (Cancel == true)
            {
                Abort(entry);
                return;
            }



            //COPY FILES


            //How many maximum errors can be displayed for this entry
            int failCount = 0;
            int allowedLogErrors = 10;


            if (copy.Items.Count() != 0)
            {
                byte[] buffer = new byte[1024 * 1024];

                long totalSize = 0;
                long totalBytes = 0;
                for (int i = 0; i < copy.Items.Count(); i++)
                {
                    using (FileStream sc = new FileStream(copy.Items[i].Source, FileMode.Open, FileAccess.Read))
                    {
                        totalSize += sc.Length;
                    }
                }
                double lastPercentage = 0;
                for (int i = 0; i < copy.Items.Count(); i++)
                {
                    try
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
                                    Main.AddToLog(entry, "Directory not found", "Replace File\n\n" + error.Message);
                                    return;
                                }
                                catch (IOException error)
                                {
                                    Main.AddToLog(entry, "IO Exception", "Replace File\n\n" + error.Message);
                                    return;
                                }
                                catch (UnauthorizedAccessException error)
                                {
                                    Main.AddToLog(entry, "No Access", "Replace File\n\n" + error.Message);
                                    return;
                                }
                                catch (NotSupportedException error)
                                {
                                    Main.AddToLog(entry, "Not Supported", "Replace File\n\n" + error.Message);
                                    return;
                                }
                            }
                            try
                            {
                                using (FileStream dest = new FileStream(copy.Items[i].Destination, FileMode.CreateNew, FileAccess.Write))
                                {
                                    int currentBlockSize = 0;

                                    while ((currentBlockSize = sc.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        if (Cancel == true)
                                        {
                                            Abort(entry);
                                            return;
                                        }

                                        totalBytes += currentBlockSize;
                                        double percentage = (double)totalBytes * 100.0 / totalSize;

                                        if (percentage - lastPercentage > 0.1)
                                        {
                                            lastPercentage = percentage;
                                            Entries[entry].Status = lastPercentage.ToString("0.0") + "%";
                                            Main.UpdateListItem(Entries[entry], entry);
                                        }

                                        try
                                        {
                                            dest.Write(buffer, 0, currentBlockSize);
                                        }
                                        catch (IOException error)
                                        {
                                            if (failCount < allowedLogErrors)
                                                Main.AddToLog(entry, "IO Exception", "Write Buffer\n\n" + error.Message);
                                            copyCount--;
                                            failCount++;
                                            break;
                                        }
                                        catch (ObjectDisposedException error)
                                        {
                                            if (failCount < allowedLogErrors)
                                                Main.AddToLog(entry, "Object Disposed", "Write Buffer\n\n" + error.Message);
                                            copyCount--;
                                            failCount++;
                                            break;
                                        }
                                        catch (NotSupportedException error)
                                        {
                                            if (failCount < allowedLogErrors)
                                                Main.AddToLog(entry, "Not Supported", "Write Buffer\n\n" + error.Message);
                                            copyCount--;
                                            failCount++;
                                            break;
                                        }
                                    }
                                }
                            }
                            catch (System.IO.DirectoryNotFoundException error)
                            {
                                Main.AddToLog(entry, "Directory Not Found", error.Message);
                                return;
                            }
                        }
                    }
                    catch (FileNotFoundException error)
                    {
                        if (failCount < allowedLogErrors)
                            Main.AddToLog(entry, "File Not Found", "FileStream Open\n\n" + error.Message);
                        copyCount--;
                        failCount++;
                        continue;
                    }

                    try
                    {
                        File.SetLastWriteTime(copy.Items[i].Destination, File.GetLastWriteTime(copy.Items[i].Source));
                    }
                    catch (FileNotFoundException error)
                    {
                        if (failCount < allowedLogErrors)
                            Main.AddToLog(entry, "File Not Found", "SetLastWriteTime\n\n" + error.Message);
                        copyCount--;
                        failCount++;
                        continue;
                    }
                    catch (UnauthorizedAccessException error)
                    {
                        if (failCount < allowedLogErrors)
                            Main.AddToLog(entry, "Unauthorized", "SetLastWriteTime\n\n" + error.Message);
                        copyCount--;
                        failCount++;
                        continue;
                    }
                    catch (NotSupportedException error)
                    {
                        if (failCount < allowedLogErrors)
                            Main.AddToLog(entry, "Not Supported", "SetLastWriteTime\n\n" + error.Message);
                        copyCount--;
                        failCount++;
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
                tag += "\n" + failCount + " Files Failed";
                if (copyCount == 0 && noDiffCount == 0)
                    subject = "Fail";
                else
                    subject = "Partial Success";
            }


            if (Main.CurrentListSel == entry)
                Main.EnableCancel(false);

            TimeSpan timeDiff = DateTime.Now.Subtract(startTime);

            tag += "\n\nTotal Time: " + (int)timeDiff.TotalSeconds + " Seconds";

            Main.AddToLog(entry, subject, tag);
        }
    }
}
