using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class TemperatureDisplayMode:ButtonCommandBaseClass
    {
        public IDataConverterable FirstConverter { get; set; }
        public TemperatureDisplayMode(IDataConverterable dataconverterable)
        {
            this.FirstConverter = dataconverterable;
        }
      
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conTemperatureDdisplay;
            switch (state)
            {
                case "关":
                    new TemperatureDisplayModeOn(this.FirstConverter).CommandContent();
                    break;
                case "开":
                    new TemperatureDisplayModeOFF(this.FirstConverter).CommandContent();
                    break;


                default:
                    break;
            }
        }
    }
}
