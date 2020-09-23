using System;
using System.IO;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Gabi\Downloads";
            string others = Path.Combine(path, "Others");

            Hashtable newFolders = new Hashtable
            {
                { "Documents", new string[] { ".pdf", ".doc", ".docx", ".rtf" } },
                { "Pictures", new string[] { ".JPG" } },
                { "Apps", new string[] { ".exe" } }
            };

            if (!Directory.Exists(others))
            {
                Directory.CreateDirectory(others);
            }

            foreach (string dir in newFolders.Keys)
            {
                Console.WriteLine("Copying files in directory: " + dir);
                string destPath = Path.Combine(path, dir);
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }

                foreach (string value in (string[])newFolders[dir])
                {
                    string[] files = Directory.GetFiles(path);
                    foreach (string file in files)
                    {
                        string extension = Path.GetExtension(file);
                        string fileName = Path.GetFileName(file);
                        if (extension == value)
                        {
                            Console.WriteLine(file);
                            File.Move(file, Path.Combine(destPath, fileName));
                        }
                    }
                }

                Console.WriteLine("");
            }
            string[] filesLeft = Directory.GetFiles(path);
            Console.WriteLine("Copying files in directory: " + others);
            foreach (string file in filesLeft)
            {
                Console.WriteLine(file);
                string fileName = Path.GetFileName(file);
                File.Move(file, Path.Combine(others, fileName));
            }
        }
    }
}