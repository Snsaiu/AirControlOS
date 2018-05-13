using AirControlOS.Models.Command_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.DataConverter_Interface;

namespace AirControlOS.Models.First.FirstCommands
{
    class WindPowerModelFour : ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }

        public WindPowerModelFour(IDataConverterable dataconverterable)
        {
            this.DataConverterable = dataconverterable;
        }
        public void CommandContent()
        {
            //TODO:here you overwrite command content
            string command = "0x03_0x03";
            this.DataConverterable.SendData(command);
        }
    }
}
