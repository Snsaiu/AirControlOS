using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.DataConverter_Interface;

namespace AirControlOS.Models.First.FirstCommands
{
    class CloseSuperPower:ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }

        public CloseSuperPower(IDataConverterable dataConverterable)
        {
            this.DataConverterable = dataConverterable;
        }
        public void CommandContent()
        {
            string addr = ((DataConverter_Instacne.FirstDataConverter)DataConverterable).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conAddr;
            string command =addr+ " 0x01 0x01";
            this.DataConverterable.SendData(command);
        }
    }
}
