using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.DataConverter_Interface;

namespace AirControlOS.Models.Command_Interface
{
    interface ICommandable
    {
        IDataConverterable DataConverterable { get; set; }
        void CommandContent();
    }
      
}
