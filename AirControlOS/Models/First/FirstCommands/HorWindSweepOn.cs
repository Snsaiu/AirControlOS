using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.DataConverter_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstCommands
{
    class HorWindSweepOn : ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }

        public HorWindSweepOn(IDataConverterable idataconverterable)
        {
            this.DataConverterable = idataconverterable;
        }

        public void CommandContent()
        {
            string addr = ((DataConverter_Instacne.FirstDataConverter)DataConverterable).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conAddr;
            string command = addr+" 0x0a 0x00";
            this.DataConverterable.SendData(command);
        }
    }
}

