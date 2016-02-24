using FileMappingValidationTool.Core.Models;
using FileMappingValidationTool.Core.Extensions;
using FileMappingValidationTool.Logic.Mapping;
using FileMappingValidationTool.Logic.Validation;
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
        private string _sourceFile = @"C:\BCG\25-1 RMs.xlsx";
        private string _destinationFile = @"C:\Users\dSurt1\Downloads\UploadTemplate.xlsx";
        private string _validationFile = @"C:\BCG\ValidationList.xml";
        public string FileExtensions = "Excel 2010|*.xlsx|Excel 2007|*.xls";
        public string xmlFileExtension = "XML Files (*.xml)|*.xml";
        private IMappingLogic _logic = new MappingLogic();
        private IValidationLogic _validate = new ValidationLogic();

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

        public string ValidationFile
        {
            get { return this._validationFile; }
            set
            {
                if (value != this._validationFile)
                {
                    this._validationFile = value;
                    RaisePropertyChanged("ValidationFile");
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
                _validate.Load(_sourceFile, _validationFile);
                var logs = _validate.ValidateSource();
                if (logs.Count > 0)
                {
                    logs.ExportCSV<LogData>();
                    MessageBox_Show("Error while validating source file. Please check the logs.");
                }
            }
            catch (Exception ex)
            {
                MessageBox_Show(ex.Message);
            }
        }

        private void CopyLogToCsv(List<LogData> logs)
        {
            
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
