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
    public class DirectoryOnly : FileTypes, IMD5
    {
        public void DirectoryFiles(string directory, string userOutputPath)
        {
            try
            {
                string[] filePaths = Directory.GetFiles(directory);
                foreach (string filePath in filePaths)
                {
                    var MD5HashFile = CreateMD5(filePath);

                    //Checks to see if there is a match with jpg files
                    if (System.Text.RegularExpressions.Regex.IsMatch(filePath, jpg, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        List<string> jpgFile = File.ReadAllLines(userOutputPath).ToList();

                        jpgFile.Add("a." + filePath);
                        jpgFile.Add("b. JPG file");
                        jpgFile.Add("c. " + MD5HashFile + "\n");
                        File.WriteAllLines(userOutputPath, jpgFile);
                    }

                    //Checks to see if there is a match with pdf files
                    else if (System.Text.RegularExpressions.Regex.IsMatch(filePath, pdf, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        List<string> pdfFile = File.ReadAllLines(userOutputPath).ToList();

                        pdfFile.Add("a." + filePath);
                        pdfFile.Add("b. PDF file");
                        pdfFile.Add("c. " + MD5HashFile + "\n");
                        File.WriteAllLines(userOutputPath, pdfFile);
                    }
                }
                Console.WriteLine("Files created. Press the Enter key to continue.");
                Console.ReadLine();
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
