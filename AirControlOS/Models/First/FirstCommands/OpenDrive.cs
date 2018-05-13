using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.DataConverter_Interface;
using System.Runtime.Remoting.Messaging;
using System.Windows;

namespace AirControlOS.Models.First.FirstCommands
{
    class OpenDrive:ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }

        public OpenDrive(IDataConverterable dataConverterable)
        {
            this.DataConverterable = dataConverterable;
        }
        public void CommandContent()
        {
            string addr = ((DataConverter_Instacne.FirstDataConverter)DataConverterable).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conAddr;
            string command = addr+" 0x00 0x01";         
            
            this.DataConverterable.SendData(command);
        }
    }
}
