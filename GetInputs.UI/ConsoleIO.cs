using GetInputs.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetInputs
{
    public class ConsoleIO
    {
        public string DirectoryPathQuestion()
        {
            Banner();
            Console.WriteLine();
            Console.WriteLine("Please enter a directory path for files to be analyzed.");
            string directory = Console.ReadLine();

            while (!Directory.Exists(directory))
            {
                Console.Clear();
                Banner();
                Console.WriteLine("File does not exist. Make sure the file location or files exist.");
                Console.WriteLine("Please enter a directory path for files to be analyzed.");
                Console.WriteLine();
                Console.WriteLine("Ex: C:\\Dev\\GetInputs\\Stuff\\Animals");
                Console.WriteLine();

                directory = Console.ReadLine();
            }
            return directory;
        }

        public string OutputPathQuestion()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a path for the output file (including file name and extension).");
            string outputPath = Console.ReadLine();
            while (!File.Exists(outputPath))
            {
                Console.Clear();
                Banner();
                Console.WriteLine("Output file path does not exist. Make sure the file location exist.");
                Console.WriteLine("Please enter a path for the output file (including file name and extension).");
                Console.WriteLine();
                Console.WriteLine("Ex: C:\\Dev\\GetInputs\\Stuff\\OutputFilesListOfStuff.txt");
                Console.WriteLine();

                outputPath = Console.ReadLine();
            }
            return outputPath;
        }

        public void FlagQuestion(string directory, string outputPath)
        {
            Console.WriteLine();
            Console.WriteLine("Is there a flag? Y/N");
            string flag = Console.ReadLine();
            flag = flag.ToUpper();

            while (flag != "Y" && flag != "N")
            {
                Console.Clear();
                Banner();
                Console.WriteLine("Make sure you typed in either Y or N. Please try again.");
                Console.WriteLine("Is there a flag? Y/N");
                Console.WriteLine();

                flag = Console.ReadLine();
                flag = flag.ToUpper();
            }

            if (flag == "Y")
            {
                //Gets directory and sub directories 
                var directoryAndSub = new BothDirAndSub();
                directoryAndSub.DirAndSubFiles(directory, outputPath);
            }

            else if (flag == "N")
            {
                //Gets directory only
                var directoryOnly = new DirectoryOnly();
                directoryOnly.DirectoryFiles(directory, outputPath);
            }
            else
            {
                Console.WriteLine("An error occurred. Please try again.");
            }
        }

        public string AddFiles()
        {
            Console.WriteLine();
            Console.WriteLine("Did you want to add more files? Enter Y or N.");
            string userInput = Console.ReadLine();
            userInput = userInput.ToUpper();

            while(userInput != "Y" && userInput !="N")
            {
                Console.Clear();
                Banner();
                Console.WriteLine("Make sure you typed in either Y or N. Please try again.");
                Console.WriteLine("Did you want to add more files? Enter Y or N.");
                Console.WriteLine();

                userInput = Console.ReadLine();
                userInput = userInput.ToUpper();
            }
            return userInput;
        }

        public void Banner()
        {
            Console.WriteLine("************************************");
            Console.WriteLine("**Get the Stuff!**");
            Console.WriteLine("************************************");
        }
    }
}
