using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.DataConverter_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstCommands
{
    class SubTemperature : ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }
        public SubTemperature(IDataConverterable dataconverterable)
        {
            this.DataConverterable = dataconverterable;
        }
        public void CommandContent()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)DataConverterable).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conTemperature;
            string subTemperature = "0x06_0x" + (Int32.Parse(state) - 1).ToString("X2");
            this.DataConverterable.SendData(subTemperature);
           
        }
    }
}


