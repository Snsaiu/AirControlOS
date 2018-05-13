using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class DriveState : ButtonCommandBaseClass
    {
        public IDataConverterable FirstDataConverter { get; set; }
        public DriveState(IDataConverterable firstdataconverter)
        {
            this.FirstDataConverter = firstdataconverter;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstDataConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conDriveState;
            switch (state)
            {
                case "开":
                    new OpenDrive(this.FirstDataConverter).CommandContent();
                    break;
                case "关":
                    new CloseDrive(this.FirstDataConverter).CommandContent();
                    break;
                default:
                    break;
            }

            //TODO:here choose and perform command
            //switch (this.FirstDataConverter.DataPack[1])
            //{

            //    default:
            //        break;
            //}
        }
    }
}
