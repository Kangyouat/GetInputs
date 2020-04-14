using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetInputs
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupWorkflow setUp = new SetupWorkflow();
            setUp.Start();
        }
    }
}
