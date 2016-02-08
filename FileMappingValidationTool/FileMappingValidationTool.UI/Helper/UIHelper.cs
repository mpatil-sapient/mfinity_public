using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMappingValidationTool.UI.Helper
{
    public class UIHelper
    {
        public static UIHelper GetInstance()
        {
            return new UIHelper();
        }
        public OpenFileDialog ShowFileDialog(string Filter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = Filter;
            openFileDialog.ShowDialog();
            return openFileDialog;
            //    txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }
    }
}
