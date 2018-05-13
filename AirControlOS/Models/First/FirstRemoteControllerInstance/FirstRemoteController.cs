using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.First.firstButtonCommandSets;
using AirControlOS.Models.First.FirstButtonCommandSets;
using AirControlOS.Models.RemovteController_Base;

namespace AirControlOS.Models.First.FirstRemoteControllerInstance
{

    enum WorkMode
    {
        
    }


    /// <summary>
    /// this class is a remote controller instance,it is inherit super remoteControllerBase,so 
    /// it has function include normal remoteController
    /// please note: normally ,air controller has different work state,example refrigeration,heating,so
    /// you can define a enum type data to save mode ,of course,setting should also use enum type data to save children  
    /// if you define enum type data,you should define where level as same as class,so it can be used in global,of course
    /// for extension,when you name the enum type data ,you should make sure it has unique name
    /// </summary>
    class FirstRemoteController:RemoteControllerBase
    {
        //public override void AddCommand(Enum c, ICommandable command)
        //{
        //    this.CommandDictionary.Add(index,command);
         
        //}

        //public override void RemoveCommand(string index)
        //{
        //    this.CommandDictionary.Remove(index);
        //}

        //public override void ExecuteCommand(string index)
        //{
        //   this.CommandDictionary[index].CommandContent();
        //}

        public override void AddCommand(Enum commandindex, ButtonCommandBaseClass command)
        {
            this.CommandDictionary.Add(commandindex,command);
        }

        public override void RemoveCommand(Enum commandindex)
        {
            this.CommandDictionary.Remove(commandindex);
        }

        public override void ExecuteCommand(Enum commandindex)
        {
            this.CommandDictionary[commandindex].Perform();
        }

        
    }
}
