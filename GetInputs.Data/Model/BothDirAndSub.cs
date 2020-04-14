using GetInputs.Data.Interface;
using GetInputs.Data.Misc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetInputs.Data.Model
{
    public class BothDirAndSub : FileTypes, IMD5
    {
        public void DirAndSubFiles(string directory, string userOutputPath)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(directory);
                string[] subDirectorFilePaths = Directory.GetDirectories(directory);
                foreach (string subDir in subDirectorFilePaths)
                {
                    string[] subDirectoryPathFile = Directory.GetFiles(subDir);

                    foreach (string subDirFile in subDirectoryPathFile)
                    {
                        var MD5HashFile = CreateMD5(subDirFile);

                        //Checks to see if there is a match with jpg files
                        if (System.Text.RegularExpressions.Regex.IsMatch(subDirFile, jpg, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            List<string> jpgFile = File.ReadAllLines(userOutputPath).ToList();

                            jpgFile.Add("a. " + subDirFile);
                            jpgFile.Add("b. JPG file");
                            jpgFile.Add("c. " + MD5HashFile + "\n");
                            File.WriteAllLines(userOutputPath, jpgFile);
                        }

                        //Checks to see if there is a match with pdf files
                        else if (System.Text.RegularExpressions.Regex.IsMatch(subDirFile, pdf, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                        {
                            List<string> pdfFile = File.ReadAllLines(userOutputPath).ToList();

                            pdfFile.Add("a." + subDirFile);
                            pdfFile.Add("b. PDF file");
                            pdfFile.Add("c. " + MD5HashFile + "\n");
                            File.WriteAllLines(userOutputPath, pdfFile);
                        }
                    }
                }
                DirectoryOnly directoryFiles = new DirectoryOnly();
                directoryFiles.DirectoryFiles(directory, userOutputPath);
            }

            catch (Exception e)
            {
                Console.WriteLine("An error occurred. Please try again. Press Enter to continue.");
                Console.ReadLine();
                Console.Clear();
                return;
            }
        }

        public string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sbuilder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sbuilder.Append(hashBytes[i].ToString("X2"));
                }
                return sbuilder.ToString();
            }
        }
    }
}
