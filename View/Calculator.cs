using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.View
{
    class Calculator
    {
        public static void SaveHistory(string history)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "history.txt"), true))
            {
                outputFile.WriteLine(history);
            }
        }
    }
}
