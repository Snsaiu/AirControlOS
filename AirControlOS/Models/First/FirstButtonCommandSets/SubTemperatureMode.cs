using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class SubTemperatureMode:ButtonCommandBaseClass
    {
        public IDataConverterable FirstDataConverter { get; set; }
        public SubTemperatureMode(IDataConverterable firstdataconverter)
        {
            this.FirstDataConverter = firstdataconverter;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstDataConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conTemperature;

            new SubTemperature(FirstDataConverter).CommandContent();
        
        }
    }
}
