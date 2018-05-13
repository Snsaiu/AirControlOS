using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.DataConverter_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstCommands
{
    class LightOn : ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }
        public LightOn(IDataConverterable dataconverterable)
        {
            this.DataConverterable = dataconverterable;
        }
        public void CommandContent()
        {
            string addr = ((DataConverter_Instacne.FirstDataConverter)DataConverterable).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conAddr;
            string command = addr+" 0x0b 0x00";
            this.DataConverterable.SendData(command);
        }
    }
}

