using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.AirControlFolder;
using AirControlOS.Models.AirControlListFolder;

namespace AirControlOS.Models.DataConverter_Interface
{

    public delegate void ParseDataChangedEventHandler(AirControlBase AirControl);
  public  interface IDataConverterable
    {
         string[] DataPack { get; set; }
            void ParseData();
            void SendData(string data);
        event ParseDataChangedEventHandler ParseDataChangeEvent;

      

    }
}
