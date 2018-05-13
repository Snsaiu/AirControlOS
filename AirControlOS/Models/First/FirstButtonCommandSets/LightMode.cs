using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class LightMode : ButtonCommandBaseClass
    {
        public IDataConverterable FirstDataConverter { get; set; }
        public LightMode(IDataConverterable firstdataconverter)
        {
            this.FirstDataConverter = firstdataconverter;
        }
     
             public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstDataConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conLight;
            switch (state)
            {
                case "开":
                    new LightOff(this.FirstDataConverter).CommandContent();
                    break;
                case "关":
                    new LightOn(this.FirstDataConverter).CommandContent();
                    break;
                default:
                    break;
            }
        }
    }
}
