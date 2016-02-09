using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileMappingValidationTool.ViewModel
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<string> _action;

        public DelegateCommand(Action<string> action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action.Invoke((string)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
