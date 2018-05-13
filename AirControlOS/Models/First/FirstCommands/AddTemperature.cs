using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.DataConverter_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirControlOS.Models.First.FirstCommands
{
    class AddTemperature : ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }
        public AddTemperature(IDataConverterable dataconverterable)
        {
            this.DataConverterable = dataconverterable;
        }
        public void CommandContent()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)DataConverterable).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conTemperature;
            string addr = ((DataConverter_Instacne.FirstDataConverter)DataConverterable).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conAddr;
            string addTemperature = addr+" 0x06 0x"+(Int32.Parse(state) + 1).ToString("X2");
            this.DataConverterable.SendData(addTemperature);
        }
    }
}

