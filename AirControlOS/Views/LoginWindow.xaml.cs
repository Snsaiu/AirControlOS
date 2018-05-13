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
using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.ViewModels;

namespace AirControlOS.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindowViewModel LoginWindowView { get; set; }
        public LoginWindow(IDataConverterable dataConverterable)
        {
            InitializeComponent();
           this.LoginWindowView = new LoginWindowViewModel(dataConverterable);
            this.DataContext = this.LoginWindowView;
        }

        public LoginWindowViewModel GetLoginWindowViewModel()
        {
            if (this.LoginWindowView != null)
            {
                return this.LoginWindowView;
            }
            else
            {
                return null;
            }
        }
    }
}
