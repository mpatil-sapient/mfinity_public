using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.Core.Helpers
{
    public class CSVHelper
    {
        public static void ExportCSV(string csv)
        {
            string pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = pathDesktop + "\\ValidationLogs.csv";

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            using (System.IO.TextWriter writer = File.CreateText(filePath))
            {
                writer.WriteLine(csv);
            }
        }
    }
}
