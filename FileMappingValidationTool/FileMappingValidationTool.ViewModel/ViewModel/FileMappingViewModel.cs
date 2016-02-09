using FileMappingValidationTool.Logic.Mapping;
using FileMappingValidationTool.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileMappingValidationTool.ViewModel
{
    public class FileMappingViewModel : BaseViewModel
    {
        private string _sourceFile = "C:\\DEV\\Workspace\\DotNet\\SampleTestData\\25-4 RMs.xlsx";
        private string _destinationFile = "C:\\DEV\\Workspace\\DotNet\\SampleTestData\\UploadTemplate(1).xlsx";
        public string FileExtensions = "Excel 2010|*.xlsx|Excel 2007|*.xls";
        private IMappingLogic _logic = new MappingLogic();

        #region *** properties ***
        public string SourceFile
        {
            get { return this._sourceFile; }
            set
            {
                if (value != this._sourceFile)
                {
                    this._sourceFile = value;
                    RaisePropertyChanged("SourceFile");
                }
            }
        }

        public string DestinationFile
        {
            get { return this._destinationFile; }
            set
            {
                if (value != this._destinationFile)
                {
                    this._destinationFile = value;
                    RaisePropertyChanged("DestinationFile");
                }
            }
        }
        #endregion

        #region *** commands ***       

        //public ICommand FileSelectCommand
        //{
        //    get { return new DelegateCommand(SelectFile); }
        //}

        //private void SelectFile(String sourceDest)
        //{

        //    if (sourceDest == "source")
        //    {
        //        this._sourceFile
        //    }
        //    else
        //    {

        //    }
        //}

        public ICommand MapFilesCommand
        {
            get { return new DelegateCommand(MapFiles); }
        }

        public ICommand ValidateSourceCommand
        {
            get { return new DelegateCommand(ValidateSource); }
        }
        #endregion

        private void MapFiles()
        {
            try
            {
                _logic.Load(_sourceFile, _destinationFile);
                _logic.Map();
            }
            catch (Exception ex)
            {
                MessageBox_Show(ex.Message);
            }
        }
        private void ValidateSource()
        {
            try
            {
                _logic.Load(_sourceFile, _destinationFile);
                String strErrors = _logic.ValidateSource();
                MessageBox_Show(strErrors);
           }
            catch (Exception ex)
            {
                MessageBox_Show(ex.Message);
            }
        }

        public void MessageBox_Callback()
        {
            //if (result == MessageBoxResult.Yes)
            {
                // Do something
            }
        }
        public event EventHandler<string> MessageBoxRequest;
        //public event EventHandler<MvvmMessageBoxEventArgs> MessageBoxRequest;
        //protected void MessageBox_Show(Action<MessageBoxResult> resultAction, string messageBoxText, 
        //    string caption = "", MessageBoxButton button = MessageBoxButton.OK, 
        //    MessageBoxImage icon = MessageBoxImage.None, MessageBoxResult defaultResult = MessageBoxResult.None, MessageBoxOptions options = MessageBoxOptions.None)
        //{
        //    if (this.MessageBoxRequest != null)
        //    {
        //        this.MessageBoxRequest(this, 
        //            new MvvmMessageBoxEventArgs(resultAction, messageBoxText, caption, button, icon, defaultResult, options));
        //    }
        //}

        protected void MessageBox_Show(string messageBoxText)
        {
            if (this.MessageBoxRequest != null)
            {
                this.MessageBoxRequest(this, messageBoxText);
            }
        }
    }
}
