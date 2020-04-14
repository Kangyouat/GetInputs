using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetInputs
{
    public class SetupWorkflow
    {
        public void Start()
        {
            try
            {
                var AddFilesAgain = "";
                while (AddFilesAgain != "N")
                {
                    Console.Clear();
                    var question = new ConsoleIO();

                    var userInputq1 = question.DirectoryPathQuestion();
                    var userInputq2 = question.OutputPathQuestion();
                    question.FlagQuestion(userInputq1, userInputq2);

                    AddFilesAgain = question.AddFiles();
                }
                Console.WriteLine("Application will now shut down. Press Enter key to continue.");
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
    }
}
