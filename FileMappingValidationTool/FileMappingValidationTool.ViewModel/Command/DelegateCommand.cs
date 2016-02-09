using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FileMappingValidationTool.ViewModel.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<string> _action1;
        private readonly Action _action2;

        public DelegateCommand(Action<string> action)
        {
            _action1 = action;
        }
        public DelegateCommand(Action action)
        {
            _action2 = action;
        }

        public void Execute(object parameter)
        {
            if(_action1 != null)
                _action1.Invoke((string)parameter);
            else if (_action2 != null)
                _action2.Invoke();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
