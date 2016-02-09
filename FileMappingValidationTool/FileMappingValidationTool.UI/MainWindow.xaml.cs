using FileMappingValidationTool.UI.Helper;
using FileMappingValidationTool.ViewModel;
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
        OpenFileDialog _sourceFile;
        OpenFileDialog _destFile;
        FileMappingViewModel _viewModel;
        UIHelper uiHelper;
        public MainWindow()
        {
            InitializeComponent();

            uiHelper = UIHelper.GetInstance();
            _viewModel = this.DataContext as FileMappingViewModel;
            _viewModel.MessageBoxRequest += new EventHandler<string>(ShowValidationMessages);
        }

        private void btnSourceFile_Click(object sender, RoutedEventArgs e)
        {
            _sourceFile = uiHelper.ShowFileDialog(_viewModel.FileExtensions);
            _viewModel.SourceFile = _sourceFile.FileName;
        }

        private void btnDestinationFile_Click(object sender, RoutedEventArgs e)
        {
            _destFile = uiHelper.ShowFileDialog(_viewModel.FileExtensions);
            _viewModel.DestinationFile = _destFile.FileName;
        }

        void ShowValidationMessages(object sender, string e)
        {
            MessageBox.Show(e);
        }

    }
}
