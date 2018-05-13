using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class TimerMode:ButtonCommandBaseClass
    {
        public IDataConverterable FirstConverter { get; set; }

        public TimerMode(IDataConverterable dataconverterable)
        {
            this.FirstConverter = dataconverterable;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conTimeMode;
            switch (state)
            {
                case "关":
                    new Timeone(this.FirstConverter).CommandContent();
                    break;
                case "一小时":
                    new TimeTwo(this.FirstConverter).CommandContent();
                    break;
                case "二小时":
                    new TimeThree(this.FirstConverter).CommandContent();
                    break;
                case "三小时":
                    new TimeOff(this.FirstConverter).CommandContent();
                    break;
                default:
                    break;
            }
        }
    }
}
