using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstButtonCommandSets
{
    class WorkModel:ButtonCommandBaseClass
    {
        public IDataConverterable FirstConverter { get; set; }
        public WorkModel(IDataConverterable dataconverterable)
        {
            this.FirstConverter = dataconverterable;
        }
        public override void Perform()
        {
            string state = ((DataConverter_Instacne.FirstDataConverter)FirstConverter).AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex).conWorkMode;
            switch (state)
            {
                case "除湿":
                    new AutoMode(this.FirstConverter).CommandContent();
                    break;
                case "自动":
                    new Heating(this.FirstConverter).CommandContent();
                    break;
                case "制热":
                    new Refrigeration(this.FirstConverter).CommandContent();
                    break;
                case "制冷":
                    new Blow(this.FirstConverter).CommandContent();
                    break;
                case "吹风":
                    new Dehumidification(this.FirstConverter).CommandContent();
                    break;
                default:
                    break;
            }


        }

    }
}
