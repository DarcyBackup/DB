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
        
        private bool Different(string path1, string path2)
        {

            if (File.Exists(path2) == false)
                return true;



            long length1 = new System.IO.FileInfo(path1).Length;
            long length2 = new System.IO.FileInfo(path2).Length;

            if (length1 != length2)
                return true;


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

            for (int i = 0; i < entries.Length; i ++)
            {
                if (entries[i].entry == entry)
                    return i;
            }

            return -1;
        }
        private void Perform(int entry)
        {

            entries[entry].lastPerformed = "In Progress";

            Save();

            RemoveFromList(entry);
            AddToList(entries[entry], entry);

            bool differential = entries[entry].differential;

            string source = entries[entry].source;
            bool file = false;
            bool directory = false;

            file = File.Exists(source);
            directory = Directory.Exists(source);
            if (file == false)
            {
                if (directory == false)
                {
                    MessageBox.Show("Can not find " + source , "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            if (Directory.Exists(entries[entry].destination) == false)
            {
                try
                {
                    System.IO.Directory.CreateDirectory(entries[entry].destination);
                }
                catch (System.NotSupportedException)
                {
                    MessageBox.Show("Error in backup: " + entries[entry].destination + " is an illegal destination", "Error", MessageBoxButtons.OK);
                    return;
                }
            }

            /*
            *
            *MODES
            *
            */
            //ONLY CHANGED FILES = 1
            //NEW COPY = 2
            //REPLACE = 3

            int mode = 1;


            if (file)
            {
                string[] strArray = source.Split('\\');
                string filename = strArray[strArray.Length - 1];
                string destination = entries[entry].destination; //+ filename;
                
                if (mode == 1)
                {
                    bool different = Different(source, destination);
                    if (different)
                    {
                        try
                        {
                            System.IO.File.Copy(source, destination + filename, true);
                        }
                        catch (IOException error)
                        {
                            MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                            throw;
                        }
                        
                    }
                }
                else if (mode == 2)
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
                    }
                    catch (IOException error)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                        throw;
                    }

                }
                else
                {
                    try
                    {
                        System.IO.File.Copy(source, destination + filename, true);
                    }
                    catch (IOException error)
                    {
                        MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                        throw;
                    }
                }
            }
            else if (directory)
            {
                
                string[] files = System.IO.Directory.GetFiles(source);
                string destination = entries[entry].destination;

                if (mode == 1)
                {
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(destination, fileName);

                        if (Different(source + "\\" + fileName, destFile))
                        {
                            try
                            {
                                System.IO.File.Copy(s, destFile, true);
                            }
                            catch (IOException error)
                            {
                                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                                throw;
                            }
                        }
                    }
                }
                else if (mode == 2)
                {
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(destination, fileName);

                        if (Different(source + "\\" + fileName, destFile))
                        {
                            try
                            {
                                String timestring = DateTime.Now.ToString(" yyyyMMddHHmmss");
                                System.IO.Directory.CreateDirectory(entries[entry].destination);
                            }
                            catch (IOException error)
                            {
                                MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                                throw;
                            }
                        }
                    }
                }
                else
                {
                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(destination, fileName);
                        try
                        {
                            System.IO.File.Copy(s, destFile, true);
                        }
                        catch (IOException error)
                        {
                            MessageBox.Show(error.Message, "Error", MessageBoxButtons.OK);
                            throw;
                        }
                    }
                }
            }
        }
    }
}
