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
                System.IO.Directory.CreateDirectory(entries[entry].destination);
            }
            
            if (file)
            {
                string[] strArray = source.Split('\\');
                string filename = strArray[strArray.Length - 1];
                string destination = entries[entry].destination + filename;
                if (differential)
                {
                    bool different = Different(source, destination);
                    if (different)
                    {
                        System.IO.File.Copy(source, destination, true);
                    }
                }
                else
                {
                    System.IO.File.Copy(source, destination, true);
                }
            }
            else if (directory)
            {
                if (differential)
                {
                    string[] files = System.IO.Directory.GetFiles(source);
                    string destination = entries[entry].destination;

                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(destination, fileName);

                        if (Different(source + "\\" + fileName, destFile))
                            System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    string[] files = System.IO.Directory.GetFiles(source);
                    string destination = entries[entry].destination;

                    foreach (string s in files)
                    {
                        string fileName = System.IO.Path.GetFileName(s);
                        string destFile = System.IO.Path.Combine(destination, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
            }
        }
    }
}
