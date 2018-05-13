using AirControlOS.Models;
using AirControlOS.Models.AirControlListFolder;
using AirControlOS.Models.DataConverter_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Views
{
    class ListWindowViewModel
    {

        public ListWindowModel ListWindowMode { get; set; }

        public ListWindowDelegateCommand GetTest { get; set; }

        //todo:this command is demo 
        public ListWindowDelegateCommand Lc { get; set; }

        //simple batch command prop
        public ListWindowDelegateCommand SimpleBatchCommand { get; set; }

       // to controller prop
       public ListWindowDelegateCommand ToControllerCommand { get; set; }

        //TopView Prop
        public ListWindowDelegateCommand TopViewCommand { get; set; }

        public ListWindowDelegateCommand MultiBatchCommand { get; set; }

        public ListWindowViewModel(AirControlList AirControllist,IDataConverterable DataConver)
        {
            this.ListWindowMode = new ListWindowModel(AirControllist,DataConver);
            this.GetTest = new ListWindowDelegateCommand();
        
            this.Lc = new ListWindowDelegateCommand();
        
            //simple batch command
            this.SimpleBatchCommand = new ListWindowDelegateCommand();
            this.SimpleBatchCommand.ExecuteCommand = new Action<object>(this.ListWindowMode.Simplebatch);

            // to controller command
            this.ToControllerCommand = new ListWindowDelegateCommand();
            this.ToControllerCommand.ExecuteCommand = new Action<object>(this.ListWindowMode.ToController);

            //TopView command
            this.TopViewCommand = new ListWindowDelegateCommand();
            this.TopViewCommand.ExecuteCommand = new Action<object>(this.ListWindowMode.TOPView);

            // multi batch command

            this.MultiBatchCommand = new ListWindowDelegateCommand();
            this.MultiBatchCommand.ExecuteCommand = new Action<object>(this.ListWindowMode.MulitBatch);
        }
    }
}
