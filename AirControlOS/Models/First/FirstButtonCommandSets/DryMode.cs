using AirControlOS.Models.DataConverter_Instacne;
using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class DryMode:ButtonCommandBaseClass
    {
        public IDataConverterable FirstConverter { get; set; }
        public DryMode(IDataConverterable dataconverterable)
        {
            this.FirstConverter = dataconverterable;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conDry;
            switch (state)
            {
                case "开":
                    new DryModeOff(this.FirstConverter).CommandContent();
                    break;
                case "关":
                    new DryModeOn(this.FirstConverter).CommandContent();
                    break;
                default:
                    break;
            }

        }
    }
}
