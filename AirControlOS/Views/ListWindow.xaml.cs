using AirControlOS.Models.AirControlListFolder;
using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirControlOS.Views
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        private AirControlList ACL { get; set; }
        public ListWindow(object obj,IDataConverterable DataConverter)
        {
          
            InitializeComponent();
            if (obj is AirControlList)
            {
                this.ACL = obj as AirControlList;

                this.list.DataContext = this.ACL;
            }
            this.DataContext = new ListWindowViewModel(ACL,DataConverter);

        }
    }
}
