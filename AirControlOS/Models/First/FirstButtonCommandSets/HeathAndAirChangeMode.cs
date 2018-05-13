using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class HeathAndAirChangeMode : ButtonCommandBaseClass
    {
        public IDataConverterable FirstConverter { get; set; }
        public HeathAndAirChangeMode(IDataConverterable dataconverterable)
        {
            this.FirstConverter = dataconverterable;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conHeathAndAirChangeMode;
            switch (state)
            {
                case "关":
                    new OnlyHeath(this.FirstConverter).CommandContent();
                    break;
                case "健康模式":
                    new OnlyAirChange(this.FirstConverter).CommandContent();
                    break;
                case "换气模式":
                    new HeathAndAirChange(this.FirstConverter).CommandContent();
                    break;
                case "健康换气模式":
                    new HeathAndAirChangeModelOff(this.FirstConverter).CommandContent();
                    break;
                default:
                    break;
            }
        }
    }
}
