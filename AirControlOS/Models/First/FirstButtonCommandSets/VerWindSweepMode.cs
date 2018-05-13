using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class VerWindSweepMode : ButtonCommandBaseClass
    {
        public IDataConverterable FirstDataConverter { get; set; }
        public VerWindSweepMode(IDataConverterable firstdataconverter)
        {
            this.FirstDataConverter = firstdataconverter;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstDataConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conUpDownWindsweep;

            switch (state)
            {
                case "开":
                    new VerWindSweepOff(FirstDataConverter).CommandContent();
                    break;
                case "关":
                    new VerWindSweepOn(FirstDataConverter).CommandContent();
                    break;
                default:
                    break;
            }
        }
    }
}

