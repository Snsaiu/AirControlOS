using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class SetTemperatureMode:ButtonCommandBaseClass
    {
        public IDataConverterable FirstConverter { get; set; }
        public SetTemperatureMode(IDataConverterable datavonverterable)
        {
            this.FirstConverter = datavonverterable;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conSetTeamperatureMode;
            //switch (state)
            //{
            //    case "健康模式":
            //        new OnlyHeath(this.FirstConverter).CommandContent();
            //        break;          
            //    default:
            //        break;
            //}
        }
    }
}
