using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirControlOS.Models
{
    class ListWindowDelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Func<object,bool> CanExecuteCommand { get; set; }
        public Action<object> ExecuteCommand { get; set; }
        


        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand!=null)
            {
                return this.CanExecuteCommand(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (this.ExecuteCommand!=null)
            {
                this.ExecuteCommand(parameter);
            }
        }
       



    }
}
