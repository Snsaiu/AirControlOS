using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.DataConverter_Interface;

namespace AirControlOS.Models.First.FirstCommands
{
    class SetWindPowerUpper:ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }

        public SetWindPowerUpper(IDataConverterable dataconvertable)
        {
            this.DataConverterable = dataconvertable;
        }

        public void CommandContent()
        {
            string commandinformation = "set wind power level +1";
            this.DataConverterable.SendData(commandinformation);
        }
    }
}
