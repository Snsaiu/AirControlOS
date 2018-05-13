using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class WindPowerMode:ButtonCommandBaseClass
    {
        public IDataConverterable FirstConverter { get; set; }
        public WindPowerMode(IDataConverterable dataconverterable)
        {
            this.FirstConverter = dataconverterable;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conWindPowerMode;
            switch (state)
            {
                case "四级":
                    new WindPowerModeOne(this.FirstConverter).CommandContent();
                    break;
                case "一级":
                    new WindPowerModeTwo(this.FirstConverter).CommandContent();
                    break;
                case "二级":
                    new WindPowerModeThree(this.FirstConverter).CommandContent();
                    break;
                case "三级":
                    new WindPowerModelFour(this.FirstConverter).CommandContent();
                    break;
                default:
                    break;
            }
        }
    }
}
