using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class SilenceMode:ButtonCommandBaseClass
    {
        public IDataConverterable FirstConverter { get; set; }
        public SilenceMode(IDataConverterable dataconverterable)
        {
            this.FirstConverter = dataconverterable;
        }

        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conSlienceMode;
            switch (state)
            {
                case "关":
                    new  Silence(this.FirstConverter).CommandContent();
                    break;
                case "静音":
                    new AutoSilence(this.FirstConverter).CommandContent();
                    break;
                case "自动静音":
                    new SilenceOff(this.FirstConverter).CommandContent();
                    break;
              
                default:
                    break;
            }
        
        }
    }
}
