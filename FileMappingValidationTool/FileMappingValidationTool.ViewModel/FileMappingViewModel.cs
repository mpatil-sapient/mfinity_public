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
        private string sourceFile, destinationFile;
        public string FileExtensions = "Excel 2010|*.xlsx|Excel 2007|*.xls";

        #region *** properties ***
        public string SourceFile
        {
            get { return this.sourceFile; }
            set
            {
                if (value != this.sourceFile)
                {
                    this.sourceFile = value;
                    RaisePropertyChanged("SourceFile");
                }
            }
        }

        public string DestinationFile
        {
            get { return this.destinationFile; }
            set
            {
                if (value != this.destinationFile)
                {
                    this.destinationFile = value;
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
        //        this.sourceFile
        //    }
        //    else
        //    {

        //    }
        //}
        #endregion
    }
}
