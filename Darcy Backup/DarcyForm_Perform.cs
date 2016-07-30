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

        private string[] AddToStringArray(string[] array, string[] addArray)
        {
            string[] newArray = new string[array.Length + addArray.Length];

            for (int i = 0; i < array.Length; i++)
                newArray[i] = array[i];

            for (int i = 0; i < addArray.Length; i++)
                newArray[array.Length + i] = addArray[i];

            return newArray;
        }
        
        private bool Different(string path1, string path2)
        {

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


            //bool checksum = false; //This will later be an option in the interface
            //if (checksum == false)
                //return false;

            
            string checksum1, checksum2;
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path1))
                {
                    checksum1 = Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path2))
                {
                    checksum2 = Encoding.Default.GetString(md5.ComputeHash(stream));
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
        private void Perform(int entry)
        {

            Entries[entry].Status = "In Progress";

            //int selectedIndex = GetSelectedListIndex(List_Backup);
            //if (RemoveFromList(Entries[entry], entry) == true)
                //AddToList(Entries[entry], entry, selectedIndex);
            UpdateListItem(Entries[entry], entry);


            int copyCount = 0;
            int noDiffCount = 0;

            string source = Entries[entry].Source;
            bool file = false;
            bool directory = false;

            file = File.Exists(source);
            directory = Directory.Exists(source);
            if (file == false)
            {
                if (directory == false)
                {
                    //MessageBox.Show("Could not find " + source , "Error", MessageBoxButtons.OK);
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
                    //MessageBox.Show("Error in backup: " + Entries[entry].Destination + " is an illegal destination", "Error", MessageBoxButtons.OK);
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
                    string[] split = destination.Split('\\');
                    if (split[split.Length - 1] == "")
                        destination = destination.Remove(destination.Length - 1, 1);

                    bool different = Different(source, destination + "\\" + filename);
                    if (different)
                    {
                        try
                        {
                            System.IO.File.Copy(source, destination + "\\" + filename, true);
                            copyCount++;
                        }
                        catch (IOException error)
                        {
                            //MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                            AddToLog(entry, "IO Exception", error.Message);
                            return;
                        }

                    }
                    else
                        noDiffCount++;
                }
                else if (mode == "New Copies")
                {
                    try
                    {
                        strArray = filename.Split('.');
                        string extension = strArray[strArray.Length - 1];


                        string tempString = strArray[0];
                        for (int i = 1; i < strArray.Length-1; i++)
                            tempString += "." + strArray[i];
                        filename = tempString;


                        String timestring = DateTime.Now.ToString(" (yyyyMMdd-HH.mm)");
                        string fullDest = destination + filename + timestring + '.' + extension;
                        System.IO.File.Copy(source, fullDest, true);
                        copyCount++;
                    }
                    catch (IOException error)
                    {
                        //MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                        AddToLog(entry, "IO Exception", error.Message);
                        return;
                    }

                }
                else if (mode == "Replace files")
                {
                    try
                    {
                        System.IO.File.Copy(source, destination + filename, true);
                        copyCount++;
                    }
                    catch (IOException error)
                    {
                        //MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
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
                                //MessageBox.Show("Error in backup: " + Entries[entry].Destination + " is an illegal destination", "Error", MessageBoxButtons.OK);
                                AddToLog(entry, "Illegal destination", "Illegal destination: " + Entries[entry].Destination + destAdd);
                                return;
                            }
                        }
                        

                        files = System.IO.Directory.GetFiles(folders[i]);

                        foreach (string s in files)
                        {
                            string fileName = System.IO.Path.GetFileName(s);
                            string destFile = System.IO.Path.Combine(destination + destAdd + "\\", fileName);

                            if (Different(source + destAdd + "\\" + fileName, destFile))
                            {
                                try
                                {
                                    System.IO.File.Copy(s, destFile, true);
                                    File.SetLastWriteTime(destFile, File.GetLastWriteTime(s));
                                    copyCount++;
                                }
                                catch (IOException error)
                                {
                                    //MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
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
                        //MessageBox.Show("Error in backup: " + Entries[entry].Destination + " is an illegal destination", "Error", MessageBoxButtons.OK);
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
                            //MessageBox.Show("Error in backup: " + Entries[entry].Destination + " is an illegal destination", "Error", MessageBoxButtons.OK);
                            AddToLog(entry, "Illegal destination", "Illegal destination: " + Entries[entry].Destination);
                            return;
                        }
                    }

                    foreach (string newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
                    {
                        try
                        {
                            File.Copy(newPath, newPath.Replace(source, destination), true);
                            copyCount++;
                        }
                        catch (IOException error)
                        {
                            //MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
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
                            //MessageBox.Show("Error in backup: " + Entries[entry].Destination + " is an illegal destination", "Error", MessageBoxButtons.OK);
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
                            //MessageBox.Show("Error in backup: " + Entries[entry].Destination + " is an illegal destination", "Error", MessageBoxButtons.OK);
                            AddToLog(entry, "Illegal destination", "Illegal destination: " + Entries[entry].Destination);
                            return;
                        }
                    }

                    foreach (string newPath in Directory.GetFiles(source, "*.*", SearchOption.AllDirectories))
                    {
                        try
                        {
                            File.Copy(newPath, newPath.Replace(source, destination), true);
                            copyCount++;
                        }
                        catch (IOException error)
                        {
                            //MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                            AddToLog(entry, "IO Exception", error.Message);
                            return;
                        }
                    }
                }
            }

            string tag = "";

            tag += copyCount;

            if (copyCount == 1)
                tag += " File copied";
            else
                tag += " Files copied";

            if (noDiffCount == 1)
                tag += "\n1 File not different";
            else if (noDiffCount > 1)
                tag += "\n" + noDiffCount + " Files not different";


            AddToLog(entry, "Backup Succeeded", tag);
        }
    }
}
