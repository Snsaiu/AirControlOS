﻿using AirControlOS.Models.Command_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.DataConverter_Interface;

namespace AirControlOS.Models.First.FirstCommands
{
    class DryModeOff : ICommandable
    {
        public IDataConverterable DataConverterable { get; set; }
        public DryModeOff(IDataConverterable dataconverterable)
        {
            this.DataConverterable = dataconverterable;
        }
        public void CommandContent()
        {
            //TODO:here overwrite command content;
            string addr = ((DataConverter_Instacne.FirstDataConverter)DataConverterable).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conAddr;
            string command =addr+" 0x0d 0x01";
            this.DataConverterable.SendData(command);
        }
    }
}
