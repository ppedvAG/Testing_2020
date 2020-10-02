using ppedv.MittagsHunger.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.MittagsHunger.UI.WPF.ViewModel
{
    class SaveCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            core.Repository.SaveAll();
        }
        Core core;
        public SaveCommand(Core core)
        {
            this.core = core;
        }
    }
}
