using FileMappingValidationTool.UI.Helper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileMappingValidationTool.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UIHelper uiHelper = UIHelper.GetInstance();
        OpenFileDialog sourceFile;
        OpenFileDialog destFile;
        public MainWindow()
        {
            InitializeComponent();


        }

        private void btnSourceFile_Click(object sender, RoutedEventArgs e)
        {
            sourceFile = uiHelper.ShowFileDialog("Excel 2007|*.xls|Excel 2010|*.xlsx");
            txtSource.Text = sourceFile.FileName;
        }

        private void btnDestinationFile_Click(object sender, RoutedEventArgs e)
        {
            destFile = uiHelper.ShowFileDialog("Excel 2007|*.xls|Excel 2010|*.xlsx");
            txtDestination.Text = destFile.FileName;
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
