using AirControlOS.Models.Command_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.DataConverter_Interface;

namespace AirControlOS.Models.First.FirstCommands
{
    class Blow : ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }
        public Blow(IDataConverterable idataconverterable)
        {
            this.DataConverterable = idataconverterable;
        }
        public void CommandContent()
        {
            //TODO:write command in here
            string addr = ((DataConverter_Instacne.FirstDataConverter)DataConverterable).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conAddr;
            string command = addr+" 0x02 0x03";
            this.DataConverterable.SendData(command);
        }
    }
}
