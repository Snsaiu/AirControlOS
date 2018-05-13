using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AirControlOS.Models.DataConverter_Interface;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace AirControlOS.ViewModels
{
   public class LoginWindowViewModel:NotificationObject
    {

        public delegate bool ReturnSerialPortEventHandler(string[] PortInfo);

        public event ReturnSerialPortEventHandler ReturnSerialPortEvent;
        public LoginWindowViewModel(IDataConverterable dataConverterable)
        {
            this.DataConverterable = dataConverterable;
        }
        public IDataConverterable DataConverterable { get; set; }

        private string portName = null;
        /// <summary>
        /// PortName
        /// </summary>
        public string PortName
        {
            get
            {
                return portName;
            }

            set
            {
                portName = value;this.RaisePropertyChanged("PortName",value);
            }
        }
        /// <summary>
        /// PortRate
        /// </summary>
        public string PortRate
        {
            get
            {
                return portRate;
            }

            set
            {
                portRate = value;this.RaisePropertyChanged("PortRate",value);
            }
        }

        private string portRate = null;

        public ICommand CheckPortCommand {
            get { return new DelegateCommand<Window>(((window) =>
            {
                string[] PortInformation = new string[2];
                PortInformation[0] = this.PortName;
                PortInformation[1] = this.PortRate;
                if (ReturnSerialPortEvent != null)
                {
                    if (ReturnSerialPortEvent(PortInformation))
                    {
                        window.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }));}
        }

     
       }



    
}
