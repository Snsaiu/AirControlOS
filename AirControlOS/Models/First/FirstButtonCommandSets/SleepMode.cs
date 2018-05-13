using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class SleepMode:ButtonCommandBaseClass
    {
        public IDataConverterable FirstConverter { get; set; }
        public SleepMode(IDataConverterable dataconverterable)
        {
            this.FirstConverter = dataconverterable;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conSleepMode;
            switch (state)
            {
                case "关":
                    new SleepModeOne(this.FirstConverter).CommandContent();
                    break;
                case "一小时":
                    new SleepModeTwo(this.FirstConverter).CommandContent();
                    break;
                case "二小时":
                    new SleepModeThree(this.FirstConverter).CommandContent();
                    break;
                case "三小时":
                    new SleepModeOff(this.FirstConverter).CommandContent();
                    break;
                default:
                    break;
            }
        }
    }
}
