using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.AirControlFolder
{
    //this class is a base class of all aircontrol 
    public abstract class AirControlBase : INotifyPropertyChanged
    {
        private string _conAddr = null;
        public string conAddr { get { return _conAddr; } set { _conAddr = value;this.RaisePropertyChanged("conAddr"); } }


        private string _conDriveState = null;
        public string conDriveState { get { return _conDriveState; } set { _conDriveState = value; this.RaisePropertyChanged("conDriveState"); } }

        private string _conSuperPowerMode = null;
        public string conSuperPowerMode { get { return _conSuperPowerMode; } set { _conSuperPowerMode = value; this.RaisePropertyChanged("conSuperPowerMode"); } }
        private string _conWorkMode = null;
        public string conWorkMode { get { return _conWorkMode; } set { _conWorkMode = value; this.RaisePropertyChanged("conWorkMode"); } }
        private string _conWindPowerMode = null;
        public string conWindPowerMode { get { return _conWindPowerMode; } set { _conWindPowerMode = value; this.RaisePropertyChanged("conWindPowerMode"); } }
        private string _conHeathAndAirChangeMode = null;
        public string conHeathAndAirChangeMode { get { return _conHeathAndAirChangeMode; } set { _conHeathAndAirChangeMode = value; this.RaisePropertyChanged("conHeathAndAirChangeMode"); } }

        private string _conSlienceMode = null;
        public string conSlienceMode { get { return _conSlienceMode; } set { _conSlienceMode = value; this.RaisePropertyChanged("conSlienceMode"); } }

        private string _conSetTeamperatureMode = null;
        public string conSetTeamperatureMode { get { return _conSetTeamperatureMode; } set { _conSetTeamperatureMode = value; this.RaisePropertyChanged("conSetTeamperatureMode"); } }
        private string _conSleepMode = null;
        public string conSleepMode { get { return _conSleepMode; } set { _conSleepMode = value; this.RaisePropertyChanged("conSleepMode"); } }

        private string _conTimeMode = null;
        public string conTimeMode { get { return _conTimeMode; } set { _conTimeMode = value; this.RaisePropertyChanged("conTimeMode"); } }

        private string _conUpDownWindsweep = null;
        public string conUpDownWindsweep { get { return _conUpDownWindsweep; } set { _conUpDownWindsweep = value; this.RaisePropertyChanged("conUpDownWindsweep"); } }

        private string _conLeftRigetWindsweep = null;
        public string conLeftRigetWindsweep { get { return _conLeftRigetWindsweep; } set { _conLeftRigetWindsweep = value; this.RaisePropertyChanged("conLeftRigetWindsweep"); } }

        private string _conLight = null;
        public string conLight { get { return _conLight; } set { _conLight = value; this.RaisePropertyChanged("conLight"); } }

        private string _conTemperatureDdisplay = null;
        public string conTemperatureDdisplay { get { return _conTemperatureDdisplay; } set { _conTemperatureDdisplay = value; this.RaisePropertyChanged("conTemperatureDdisplay"); } }

        private string _conTemperature = null;
        public string conTemperature { get { return _conTemperature; } set { _conTemperature = value; this.RaisePropertyChanged("conTemperature"); } }
        private string _conDry = null;
        public string conDry { get { return _conDry; } set { _conDry = value; this.RaisePropertyChanged("conDry"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string Propertyname)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Propertyname));
            }
        }

    }
}




