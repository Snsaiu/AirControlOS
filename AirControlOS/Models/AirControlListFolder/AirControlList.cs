using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirControlOS.Models.AirControlFolder;
using System.Windows;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using AirControlOS.Models.DataConverter_Instacne;
using AirControlOS.Models.DataConverter_Interface;

namespace AirControlOS.Models.AirControlListFolder
{
    class AirControlList: ListWindowNotifyObject
    {
      
        private ObservableCollectionEx<AirControlBase> _allaircontrollist = null;
        public ObservableCollectionEx<AirControlBase> AllAirControlList { get { return _allaircontrollist; } set { _allaircontrollist = value;this.RaisePropertyChanged("AllAirControlList"); } }


        public AirControlList()
        {

            this.AllAirControlList = new ObservableCollectionEx<AirControlBase>();

        }


       
        public AirControlBase GetAirControl(int index)
        {
            try
            {
                return this.AllAirControlList[index];
            }
            catch (Exception)
            {
                return this.AllAirControlList[0];

            }
           
        }

        public void AddAirControl(AirControlBase AirControl)
        {
           this.AllAirControlList.Add(AirControl);
        }

        public void RemoveAll()
        {
            this.AllAirControlList.Clear();
        }

        public void RemoveAt(int index)
        {
            this.AllAirControlList.RemoveAt(index);
        }

        public void Insert(int index,AirControlBase acb)
        {
            this.AllAirControlList.Insert(index, acb);
        }

        public int GetCount()
        {
            return this.AllAirControlList.Count;
        }
    }
}
