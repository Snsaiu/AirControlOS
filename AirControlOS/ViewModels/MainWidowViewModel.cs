using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AirControlOS.Models.Command_Interface;
using AirControlOS.Models.DataConverter_Instacne;
using AirControlOS.Models.DataConverter_Interface;
using AirControlOS.Models.First.FirstCommands;
using AirControlOS.Models.First.FirstRemoteControllerInstance;
using AirControlOS.Models.RemovteController_Base;
using AirControlOS.Views;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using AirControlOS.Models.First.firstButtonCommandSets;
using AirControlOS.Models.First.FirstButtonCommandSets;
using AirControlOS.Models.AirControlFolder;
using AirControlOS.Models.AirControlListFolder;
using AirControlOS.Models;

namespace AirControlOS.ViewModels
{


    class MainWidowViewModel : NotificationObject
    {
       
        /*------------------------------- this area for statement all commands-------------------*/

        public DelegateCommand OpenAirControllerCommand { get; set; }

        public AirControlList AirControlList { get; set; }
        /*---------------------------statement all commands end---------------------------*/


        public RemoteControllerBase MyRemoteController { get; set; }
        public IDataConverterable DataConverterable { get; set; }

        public LoginWindow LoginWindow { get; set; }
        public LoginWindowViewModel LoginWindowViewModel { get; set; }
        #region 
        /// <summary>
        /// this property WorkModeDisplay is responsible for display work model like heating refrigeration or other mode
        /// </summary>
        private string _workModeDisplay = null;
        public string WorkModeDisplay
        {
            get
            {
                return _workModeDisplay;
            }

            set
            {
                _workModeDisplay = value;
                this.RaisePropertyChanged("WorkModeDisplay", value);
            }
        }
        /// <summary>
        /// this property TemperautureDisplay is responsible for display temperature like 30℃
        /// </summary>
        public string TemperatureDisplay
        {
            get
            {
                return _temperatureDisplay;
            }

            set
            {
                _temperatureDisplay = value;
                this.RaisePropertyChanged("TemperatureDisplay", value);
            }
        }

        private string _temperatureDisplay = null;
        /// <summary>
        /// this property HealthView is responsible for display text heath
        /// </summary>
        /// 
        private string _healthView;
        public string HealthView
        {
            get
            {
                return _healthView;
            }
            set
            {
                _healthView = value;
                this.RaisePropertyChanged("HealthView", value);
            }
        }
        /// <summary>
        /// this property SuperPowerView is responsible for display SuperPower
        /// </summary>
        private string _superPowerView;
        public string SuperPowerView
        {
            get
            {
                return _superPowerView;
            }
            set
            {
                _superPowerView = value;
                this.RaisePropertyChanged("SuperPowerView", value);
            }
        }
        /// <summary>
        /// this property DryView is responsible for display dry
        /// </summary>
        private string _dryView;
        public string DryView
        {
            get
            {
                return _dryView;
            }
            set
            {
                _dryView = value;
                this.RaisePropertyChanged("DryView", value);
            }
        }

        /// <summary>
        /// this property AirChangeView is responsible for display air change
        /// </summary>
        private string _airChangeView;
        public string AirChangeView
        {
            get
            {
                return _airChangeView;
            }
            set
            {
                _airChangeView = value;
                this.RaisePropertyChanged("AirChangeView", value);
            }
        }

        /// <summary>
        /// this property SlienceView is responsible for displya Slience
        /// </summary>
        private string _slienceView;
        public string SlienceView
        {
            get
            {
                return _slienceView;
            }
            set
            {
                _slienceView = value;
                this.RaisePropertyChanged("SlienceView", value);
            }
        }

        /// <summary>
        /// this property SleepView is responsible for display SleepView
        /// </summary>
        private string _sleepView;
        public string SleepView
        {
            get
            {
                return _sleepView;
            }
            set
            {
                _sleepView = value;
                this.RaisePropertyChanged("SleepView", value);
            }
        }
        /// <summary>
        /// this propterty HorWindView is responsible for display
        /// </summary>
        /// 
        private string _horWindView;
        public string HorWindView
        {
            get
            {
                return _horWindView;
            }
            set
            {
                _horWindView = value;
                this.RaisePropertyChanged("HorWindView", value);
            }
        }
        /// <summary>
        /// this propery  VerWindView is responsible for display
        /// </summary>
        /// 
        private string _verWindView;
        public string VerWindView
        {
            get
            {
                return _verWindView;
            }

            set
            {
                _verWindView = value;
                this.RaisePropertyChanged("VerWindView", value);
            }
        }
        /// <summary>
        /// this property StartView is responsible for display
        /// </summary>
        /// 
        private string _startView;
        public string StartView
        {
            get
            {
                return _startView;
            }
            set
            {
                _startView = value;
                this.RaisePropertyChanged("StartView", value);
            }
        }

        /// <summary>
        /// this property WindPowerLevelView is responible for display
        /// </summary>
        /// 
        private string _windPowerLevelView;
        public string WindPowerLevelView
        {
            get
            {
                return _windPowerLevelView;
            }
            set
            {
                _windPowerLevelView = value;
                this.RaisePropertyChanged("WindPowerLevelView", value);
            }
        }

        private string _setTimerView = null;
        public string SetTimerView { get { return _setTimerView; } set { _setTimerView = value; this.RaisePropertyChanged("SetTimerView"); } }
        private string _setTimerOpenView = null;
        public string SetTimerOpenView { get { return _setTimerOpenView; } set { _setTimerOpenView = value; this.RaisePropertyChanged("SetTimerOpenView"); } }

        private string _autoSlieceView = null;
        public string AutoSlieceView { get { return _autoSlieceView; } set { _autoSlieceView = value; this.RaisePropertyChanged("AutoSlieceView"); } }

        private string _currentIndex = null;
        public string Currentindex { get { return _currentIndex; } set { _currentIndex = value; this.RaisePropertyChanged("Currentindex"); } }



        #endregion

        public MainWidowViewModel()
        {

            /*---------------------- Please Note ----------------------- */
            /*--------------------next line content ,you can initial your remote controller that you want !*/
            this.MyRemoteController = new FirstRemoteController();
            /*---------------------- Please Note ----------------------- */
            /*--------------------next line content ,you can initial your data converter that you want !*/

            /*---------------------------instantiate aircontrollist----------------------*/
            this.AirControlList = new AirControlList();
            this.DataConverterable = new FirstDataConverter(this.AirControlList);



            //this.DataConverterable.ParseData();

            this.DataConverterable.ParseDataChangeEvent += DataConverterable_ParseDataChangeEvent;
            /*---------------------- Please Note ----------------------- */
            /* ---------------next line content ,you can add command to remote controller --------- */
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.SuperPowerMode, new SuperPowerMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.DriveState, new DriveState(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.HeathAndAirChangeMode, new HeathAndAirChangeMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.SilenceMode, new SilenceMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.SleepMode, new SleepMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.TemperatureDisplayMode, new TemperatureDisplayMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.TimerMode, new TimerMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.WindPowerMode, new WindPowerMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.WorkModel, new WorkModel(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.AddTemperature, new AddTemperatureMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.SubTemperature, new SubTemperatureMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.LightMode, new LightMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.HorWindSweepMode, new HorWindSweepMode(DataConverterable));
            this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.VerWindSweepMode, new VerWindSweepMode(DataConverterable));
          //  this.MyRemoteController.AddCommand(FirstButtonCommandSets.ButtonCommand.)
            /*---------------------- Please Note ----------------------- */
            /* ---------------next line content ,initial all Commands that UI and Background Interface --------- */
        }




        public ICommand AddTemperature
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.AddTemperature);
                }
        );
            }
        }

        public ICommand SubTemperature
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.SubTemperature);
                }
        );
            }
        }



        public ICommand LightMode
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.LightMode);
                }
        );
            }
        }
        public ICommand HorWindSweepMode
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.HorWindSweepMode);
                }
        );
            }
        }

        public ICommand VerWindSweepMode
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.VerWindSweepMode);
                }
        );
            }
        }
        public ICommand DriveState
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.DriveState);
                }
        );
            }
        }
        public ICommand WorkModel
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.WorkModel);
                }
        );
            }
        }

        public ICommand WindPowerMode
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.WindPowerMode);
                }
        );
            }
        }


        public ICommand TimerMode
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.TimerMode);
                }
        );
            }
        }

        public ICommand TemperatureDisplayMode
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.TemperatureDisplayMode);
                }
        );
            }
        }
        public ICommand SleepMode
        {
            get
            {
                return new DelegateCommand(() =>
        {
            this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.SleepMode);
        }
        ); } }
        public ICommand SuperPowerMode
        {
            get
            {
                return new DelegateCommand(
                    () =>
                    {
                        this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.SuperPowerMode);
                    }
                    );
            }
        }
      
        public ICommand HeathAndAirChangeMode
        {
            get
            {
                return new DelegateCommand(
                    () =>
                    {
                        this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.HeathAndAirChangeMode);
                    }
                    );
            }
        }

        public ICommand SetTemperatureMode
        {
            get
            {
                return new DelegateCommand(
                    () =>
                    {
                        this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.SetTemperatureMode);
                    }
                    );
            }
        }

        public ICommand SilenceMode
        {
            get
            {
                return new DelegateCommand(
                    () =>
                    {
                        this.MyRemoteController.ExecuteCommand(FirstButtonCommandSets.ButtonCommand.SilenceMode);
                    }
                    );
            }
        }


        //Open login window command
        public ICommand OpenloginWindowCommand
        {
            get
            {
                return new DelegateCommand((() =>
{

    this.LoginWindow = new LoginWindow(this.DataConverterable);
    this.LoginWindowViewModel = this.LoginWindow.GetLoginWindowViewModel();
    this.LoginWindowViewModel.ReturnSerialPortEvent += LoginWindowViewModel_ReturnSerialPortEvent;
    this.LoginWindow.Show();

}));
            }
        }

        // open AirControListWindow command
        public ListWindow listwindow { get; set; }
        public ICommand OpenListWindowCommand
        {


            get
            {
                return new DelegateCommand(() =>
                {
                    this.listwindow = new ListWindow(AirControlList,this.DataConverterable);
                    this.listwindow.Show();

                }
                );
            }
        }

        private bool LoginWindowViewModel_ReturnSerialPortEvent(string[] PortInfo)
        {
            FirstDataConverter f = this.DataConverterable as FirstDataConverter;
            return f.ConnectionPort(PortInfo[0], PortInfo[1]);
        }



        //Set Window Position command
        public ICommand MoveWindowCommand { get { return new DelegateCommand<Window>((window) => { window.DragMove(); }); } }
        //Set Window Size Min
        public ICommand MinSizeCommand { get { return new DelegateCommand<Window>((window) => { window.WindowState = WindowState.Minimized; }); } }
        //Close Main Window
        public ICommand CloseMainWindowCommand { get { return new DelegateCommand<Window>((window) => { window.Close(); }); } }



        /// <summary>
        /// when derive data update ,it will notify UI to update information
        /// </summary>
        /// <param name="datapack"></param>
        private void DataConverterable_ParseDataChangeEvent(AirControlBase AirControl)
        {

            //  this.TemperatureDisplay = "30 °C";
            //symbol █ █ █ █ █

            this.Currentindex = (AircontrolIndexClass.CurrentAirControlIndex+1).ToString();

            if (AirControl.conDriveState == "开")
            {


                this.StartView ="运行";
                this.TemperatureDisplay = AirControl.conTemperatureDdisplay;


                switch (AirControl.conWindPowerMode)
                {
                    case "一级":
                        this.WindPowerLevelView = "█";
                        break;
                    case "二级":
                        this.WindPowerLevelView = "█ █";
                        break;
                    case "三级":
                        this.WindPowerLevelView = "█ █ █";
                        break;
                    default:
                        break;
                }

                switch (AirControl.conUpDownWindsweep)
                {
                    case "开":
                        this.HorWindView = "上下扫风";
                        break;
                    case "关":
                        this.HorWindView = "";
                        break;
                    default:
                        break;
                }

                switch (AirControl.conLeftRigetWindsweep)
                {
                    case "开":
                        this.HorWindView = "左右扫风";
                        break;
                    case "关":
                        this.HorWindView = "";
                        break;
                    default:
                        break;
                }

                switch (AirControl.conUpDownWindsweep)
                {
                    case "开":
                        this.VerWindView = "上下扫风";
                        break;
                    case "关":
                        this.VerWindView = "";
                        break;
                    default:
                        break;
                }

                switch (AirControl.conWorkMode)
                {
                    case "自动":
                        this.WorkModeDisplay = "自动";
                        break;
                    case "制热":
                        this.WorkModeDisplay = "制热";
                        break;
                    case "制冷":
                        this.WorkModeDisplay = "制冷";
                        break;
                    case "吹风":
                        this.WorkModeDisplay = "吹风";
                        break;
                    case "除湿":
                        this.WorkModeDisplay = "除湿";
                        break;
                    default:
                        break;
                }

                switch (AirControl.conHeathAndAirChangeMode)
                {
                    case "健康模式":
                        this.HealthView = "健康";
                        this.AirChangeView = "";
                        break;
                    case "换气模式":
                        this.HealthView = "";
                        this.AirChangeView = "换气";
                        break;
                    case "健康换气模式":
                        this.HealthView = "健康";
                        this.AirChangeView = "换气";
                        break;
                    case "关":
                        this.HealthView = "";
                        break;
                    default:
                        break;
                }

                switch (AirControl.conTemperatureDdisplay)
                {
                    case "开":
                        this.TemperatureDisplay = AirControl.conTemperature+ "°C";
                        break;
                    case "关":
                        this.TemperatureDisplay = "";
                        break;
                    default:
                        break;
                }

                switch (AirControl.conDriveState)
                {
                    case "开":
                        this.DryView = "辅热";
                        break;
                    case "关":
                        this.DryView = "";
                        break;
                    default:
                        break;
                }
                switch (AirControl.conTimeMode)
                {
                    case "一小时":
                        this.SetTimerView = "1";
                        this.SetTimerOpenView = "小时后关闭";
                        break;
                    case "二小时":
                        this.SetTimerView = "2";
                        this.SetTimerOpenView = "小时后关闭";
                        break;
                    case "三小时":
                        this.SetTimerView = "3";
                        this.SetTimerOpenView = "小时后关闭";
                        break;
                    case "关":
                        this.SetTimerView = "";
                        this.SetTimerOpenView = "";
                        break;
                    default:
                        break;
                }

                switch (AirControl.conSleepMode)
                {
                    case "一小时":
                        this.SleepView = "睡眠1";                       
                        break;
                    case "二小时":
                        this.SleepView = "睡眠2";                     
                        break;
                    case "三小时":
                        this.SleepView = "睡眠3";                      
                        break;
                    case "关":
                        this.SleepView = "";                   
                        break;
                    default:
                        break;
                }

                this.TemperatureDisplay = AirControl.conTemperature+ "°C";

                switch (AirControl.conSuperPowerMode)
                {
                    case "开":
                        this.SuperPowerView = "超强";
                        break;
                    case "关":
                        this.SuperPowerView = "";
                        break;
                    
                    default:
                        break;
                }

                switch (AirControl.conSlienceMode)
                {
                    case "自动静音":
                        this.AutoSlieceView = "自动";
                        this.SlienceView = "静音";
                        break;
                    case "自动":
                        this.AutoSlieceView = "自动";
                        this.SlienceView = "";
                        break;
                    case "静音":
                        this.AutoSlieceView = "";
                        this.SlienceView = "静音";
                        break;
                    case "关":
                        this.AutoSlieceView = "";
                        this.SlienceView = "";
                        break;

                    default:
                        break;
                }
                switch (AirControl.conDry)
                {
                    case "开":
                        this.DryView = "干燥";
                        break;
                    case "关":
                        this.DryView = "";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                this.StartView = "关机";
                this.WindPowerLevelView = "";
                this.HorWindView = "";
                this.VerWindView = "";
                this.WorkModeDisplay = "";
                this.HealthView = "";
                this.TemperatureDisplay = "";
                this.DryView = "";
                this.SetTimerView = "";
                this.SetTimerOpenView = "";
                this.SleepView = "";
                this.SuperPowerView = "";
                this.AutoSlieceView = "";
                this.SlienceView = "";
                this.DryView = "";
            }

        }


    }
}
