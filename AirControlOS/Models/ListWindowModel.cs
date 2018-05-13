using AirControlOS.Models.AirControlFolder;
using AirControlOS.Models.AirControlListFolder;
using AirControlOS.Models.DataConverter_Instacne;
using AirControlOS.Models.DataConverter_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AirControlOS.Models
{
    class ListWindowModel : ListWindowNotifyObject
    {
        public AirControlList AirControlList { get; set; }

        public IDataConverterable DataConverter { get; set; }
        public ListWindowModel(AirControlList aircontrollist,IDataConverterable DataConverter)
        {
            this.AirControlList = aircontrollist;
            this.DataConverter = DataConverter;
        }


        public void Simplebatch(object obj)
        {

            if (obj is MenuItem)
            {
                MenuItem mi = obj as MenuItem;
                ContextMenu cm = mi.Parent as ContextMenu;
                if (cm.PlacementTarget is ComboBox)
                {
                    //todo:fill content
                    ComboBox Combox = cm.PlacementTarget as ComboBox;
                    //   MessageBox.Show(Combox.Name.ToString());
                    string[] splitcontent = (Combox.SelectedItem.ToString()).Split(new char[] { ':' });
                    (this.DataConverter as FirstDataConverter).SimpleBetachParser(Combox.Name,splitcontent[1].Trim());
                }
                else
                {
                    // todo: fill content
                    TextBox Textbox = cm.PlacementTarget as TextBox;
                    int res = -1;
                    if(Int32.TryParse(Textbox.Text, out res))
                    {
                        string tem = "0x"+res.ToString("X2");
                        (this.DataConverter as FirstDataConverter).SimpleBetachParser(Textbox.Name,tem);
                    }
                }
            }
        }

        public void MulitBatch(object obj)
        {
            List<object> list = obj as List<object>;

            ComboBox cb = null;
            TextBox tb = null;
     
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is ComboBox)
                {
                    cb = list[i] as ComboBox;
                    string[] splitcontent = (cb.SelectedItem.ToString()).Split(new char[] { ':' });
                    (this.DataConverter as FirstDataConverter).SimpleBetachParser(cb.Name, splitcontent[1].Trim());

                }
                else if (list[i] is TextBox)
                {
                    tb = list[i] as TextBox;
                    int res = -1;
                    if (Int32.TryParse(tb.Text, out res))
                    {
                        string tem = "0x" + res.ToString("X2");
                        (this.DataConverter as FirstDataConverter).SimpleBetachParser(tb.Name, tem);
                    }
                }
                
            }

         
        }

        public void ToController(object obj)
        {
            ListView listview = null;
            if (obj is ListView)
            {
                //todo: fill content
                listview = obj as ListView;

               
                if (listview.SelectedIndex!=-1)
                {
                //    MessageBox.Show(listview.SelectedIndex.ToString());
                    AircontrolIndexClass.CurrentAirControlIndex = listview.SelectedIndex;
                    (this.DataConverter as FirstDataConverter).UpdateControllerContent();

                }
                else
                {
                    MessageBox.Show("请在\"批视察\"中选择一个空调，然后再点击\"转到遥控器\"");
                }
            }

        }

        public void TOPView(object obj)
        {
            List<object> list = obj as List<object>;
            Window window = list[0] as Window;
            CheckBox cbox = list[1] as CheckBox;

            if (cbox.IsChecked==true)
            {
                window.Topmost = true;
            }
            else
            {
                window.Topmost = false;
            }
        }


    }
}
