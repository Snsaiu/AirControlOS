using AirControlOS.Models.DataConverter_Instacne;
using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class SuperPowerMode: ButtonCommandBaseClass
    {

        public IDataConverterable FirstConverter { get; set; }
        public SuperPowerMode(IDataConverterable firstconverter)
        {
            this.FirstConverter = firstconverter;
        }

    

        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conSuperPowerMode;
            switch (state)
            {
                case "关":
                    new SuperModeOn(this.FirstConverter).CommandContent();
                    break;
                case "开":
                    new SuperModeOff(this.FirstConverter).CommandContent();
                    break;
                default:
                    break;
            }
        }
    }
}
