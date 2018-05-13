using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.First.firstButtonCommandSets;
using AirControlOS.Models.First.FirstButtonCommandSets;

namespace AirControlOS.Models.RemovteController_Base
{
   abstract class RemoteControllerBase
   {
       public abstract void AddCommand(Enum commandindex,ButtonCommandBaseClass command);
       public abstract void RemoveCommand(Enum commandindex);
       public abstract void ExecuteCommand(Enum commandindex);

       public RemoteControllerBase()
       {
            this.CommandDictionary=new Dictionary<Enum, ButtonCommandBaseClass>();
       }
       public Dictionary<Enum, ButtonCommandBaseClass> CommandDictionary { get; set; }

     //   internal abstract void AddCommand(FirstButtonCommandSets.ButtonCommand superPowerMode1, SuperPowerMode superPowerMode2);
    }
}
