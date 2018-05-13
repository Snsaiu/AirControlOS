using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.AirControlFolder
{
    class FirstAirControl : AirControlBase
    {

        public FirstAirControl()
        {

        }
        public FirstAirControl(
            string conDriveState,
            string conSuperPowerMode,
            string conWorkMode,
            string conWindPowerMode,
            string conHeathAndAirChangeMode,
            string conSilenceMode,
            string conDry,
            string conSleepMode,
            string conTimeMode,
            string conUpDownWindsweep,
            string conLeftRigetWindsweep,
            string conLight,
            string conTemperaturedisplay,
            string conTemperature
            )
        {

            this.conDriveState = conDriveState;
            this.conSuperPowerMode = conSuperPowerMode;
            this.conWorkMode = conWorkMode;
            this.conWindPowerMode = conWindPowerMode;
            this.conHeathAndAirChangeMode = conHeathAndAirChangeMode;
            this.conSlienceMode = conSilenceMode;
            this.conDry = conDry;
            this.conSleepMode = conSleepMode;
            this.conTimeMode = conTimeMode;
            this.conUpDownWindsweep = conUpDownWindsweep;
            this.conLeftRigetWindsweep = conLeftRigetWindsweep;
            this.conLight = conLight;
            this.conTemperatureDdisplay = conTemperaturedisplay;
            this.conTemperature = conTemperature;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        

        //public string conDriveState { get; set; }
        //public string conSuperPowerMode { get; set; }
        //public string conWorkMode { get; set; }
        //public string conWindPowerMode { get; set; }
        //public string conHeathAndAirChangeMode { get; set; }
        //public string conSilenceMode { get; set; }
        //public string conSetTeamperatureMode { get; set; }
        //public string conSleepMode { get; set; }
        //public string conTimeMode { get; set; }
        //public string conUpDownWindsweep { get; set; }
        //public string conLeftRigetWindsleep { get; set; }
        //public string conLight { get; set; }
        //public string conTemperatureDdisplay { get; set; }
    }
}
