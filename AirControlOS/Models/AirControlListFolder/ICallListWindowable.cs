using AirControlOS.Models.AirControlFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.AirControlListFolder
{
    public delegate void ICallListWindowDelegate(AirControlBase Aircontrol);
    interface ICallListWindowable
    {
        event ICallListWindowDelegate ICallListWindowEvent;
    }
}
