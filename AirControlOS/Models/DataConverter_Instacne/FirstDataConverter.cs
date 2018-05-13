using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using AirControlOS.Models.DataConverter_Interface;
using System.Threading;
using AirControlOS.Models.AirControlFolder;
using AirControlOS.Models.AirControlListFolder;
using AirControlOS.Models.First.FirstRemoteControllerInstance;

namespace AirControlOS.Models.DataConverter_Instacne
{
    class FirstDataConverter : IDataConverterable
    {


        public string[] DataPack { get; set; }

        public SerialPort SerialPort { get; set; }

        public System.Timers.Timer Timer { get; set; }

        public AirControlList AirControlList { get; set; }

        public AirControlBase AirControl { get; set; }

        public string GetMcuInfo { get; set; }


        public FirstDataConverter(AirControlList aircontrollist)
        {
            this.AirControlList = aircontrollist;
            this.Timer = new System.Timers.Timer();
            this.Timer.Interval = 200;
           // this.Timer.Elapsed += Timer_Elapsed;
            
            
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.GetMcuInfo = this.SerialPort.ReadLine();
            ParseData();
            
            
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Timer.Stop();
            ParseData();
            this.Timer.Start();
        }

        /// <summary>
        /// check and connect MCU
        /// </summary>
        /// <param name="portName">get port name like COM1</param>
        /// <param name="portRate">get port rate</param>
        /// <returns>true if can open ,otherwise can not connected</returns>
        public bool ConnectionPort(string portName, string portRate)
        {

            try
            {

                this.SerialPort = new SerialPort();
                this.SerialPort.PortName = portName;
                this.SerialPort.BaudRate = Convert.ToInt32(portRate);
                
                this.SerialPort.DataBits = 8;
                this.SerialPort.Open();
                this.SerialPort.DataReceived += SerialPort_DataReceived;
                //this.Timer.Start();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
            // MessageBox.Show(portName + portRate);

        }

      
        public void ParseData()
        {
            // 0     1       2       3     4      5         6      7     8            9    10     11      12      13       14     15    16        17          18
            // 字头 后继数据 设备数量 地址 设备状态 超强模式 工作模式 风强度 健康换气模式 静音模式 温度 睡眠模式 定时模式 上下扫风 左右扫风 灯光 温度显示  干燥模式   校验和
            //0xa5 0x00 0x05 0x01 0x01 0x01 0x00 0x00 0x00 0x00 0x0b 0x01 0x00 0x00 0x01 0x00 0x01 0x00 0x00
            Random rd = new Random();
           // string getdata = "0xa5 0x00 0x05 0x0"+rd.Next(0,5).ToString()+" 0x00" + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 5).ToString() + " 0x0" + rd.Next(0, 5).ToString() + " 0x0" + rd.Next(0, 3).ToString() + " 0x00 0x0" + rd.Next(10, 50).ToString() + " 0x0" + rd.Next(0, 5).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 2).ToString() +" 0x01"+" 0x00";
            string[] splitdata = this.GetMcuInfo.Split(new char[] { ' ' });

            AircontrolIndexClass.AirControlCount = Convert.ToInt32(splitdata[2], 16);

            if (AircontrolIndexClass.UpdateIndex < AircontrolIndexClass.AirControlCount)
            {
                this.AirControl = new FirstAirControl();
                GetAirControlInfo(splitdata);
                this.AirControlList.AddAirControl(this.AirControl);
                AircontrolIndexClass.UpdateIndex++;

            }
            else if (AircontrolIndexClass.UpdateIndex == AircontrolIndexClass.AirControlCount)
            {
                if (AircontrolIndexClass.UpdateIndex2 < AircontrolIndexClass.AirControlCount)
                {
                    this.AirControl = this.AirControlList.GetAirControl(AircontrolIndexClass.UpdateIndex2);
                    GetAirControlInfo(splitdata);
                    //    this.AirControlList.RemoveAt(AircontrolIndexClass.UpdateIndex2);
                    //   this.AirControlList.Insert(AircontrolIndexClass.UpdateIndex2, this.AirControl);

                    //   MessageBox.Show(AircontrolIndexClass.AirControlCount.ToString() + "--" + AircontrolIndexClass.UpdateIndex2.ToString());
                    AircontrolIndexClass.UpdateIndex2++;

                }
                else
                {
                    AircontrolIndexClass.UpdateIndex2 = 0;
                }

                // todo:
                // this.Timer.Stop();
            }
            else
            {
                this.AirControlList.RemoveAll();
                AircontrolIndexClass.UpdateIndex = 0;
                return;
               
            }

            //todo: display aircontrol by ListWindow listview item 

           
            UpdateControllerContent();

        }

        public void UpdateControllerContent()
        {
            if (this.ParseDataChangeEvent != null)
            {
                this.ParseDataChangeEvent(this.AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex));

            }
        }

        private void GetAirControlInfo(string[] splitdata)
        {
            this.AirControl.conAddr = splitdata[3];

            switch (splitdata[4])
            {
                case "0x00":
                    this.AirControl.conDriveState = FirstFunctionCategories_C.DriveState.开.ToString();
                    break;
                case "0x01":
                    this.AirControl.conDriveState = FirstFunctionCategories_C.DriveState.关.ToString();
                    break;
                default:
                    break;
            }

            switch (splitdata[5])
            {
                case "0x00":
                    this.AirControl.conSuperPowerMode = FirstFunctionCategories_C.SuperPowerMode.开.ToString();
                    break;
                case "0x01":
                    this.AirControl.conSuperPowerMode = FirstFunctionCategories_C.SuperPowerMode.关.ToString();
                    break;
                default:
                    break;
            }

            switch (splitdata[6])
            {
                case "0x00":
                    this.AirControl.conWorkMode = FirstFunctionCategories_C.WorkModel.自动.ToString();
                    break;
                case "0x01":
                    this.AirControl.conWorkMode = FirstFunctionCategories_C.WorkModel.制热.ToString();
                    break;
                case "0x02":
                    this.AirControl.conWorkMode = FirstFunctionCategories_C.WorkModel.制冷.ToString();
                    break;
                case "0x03":
                    this.AirControl.conWorkMode = FirstFunctionCategories_C.WorkModel.吹风.ToString();
                    break;
                case "0x04":
                    this.AirControl.conWorkMode = FirstFunctionCategories_C.WorkModel.除湿.ToString();
                    break;
                default:
                    break;
            }

            switch (splitdata[7])
            {
                case "0x00":
                    this.AirControl.conWindPowerMode = FirstFunctionCategories_C.WindPowerMode.一级.ToString();
                    break;
                case "0x01":
                    this.AirControl.conWindPowerMode = FirstFunctionCategories_C.WindPowerMode.二级.ToString();
                    break;
                case "0x02":
                    this.AirControl.conWindPowerMode = FirstFunctionCategories_C.WindPowerMode.三级.ToString();
                    break;
                default:
                    break;
            }
            switch (splitdata[8])
            {
                case "0x00":
                    this.AirControl.conHeathAndAirChangeMode = FirstFunctionCategories_C.HeathAndAirChangeMode.健康模式.ToString();
                    break;
                case "0x01":
                    this.AirControl.conHeathAndAirChangeMode = FirstFunctionCategories_C.HeathAndAirChangeMode.换气模式.ToString();
                    break;
                case "0x02":
                    this.AirControl.conHeathAndAirChangeMode = FirstFunctionCategories_C.HeathAndAirChangeMode.健康换气模式.ToString();
                    break;
                case "0x03":
                    this.AirControl.conHeathAndAirChangeMode = FirstFunctionCategories_C.HeathAndAirChangeMode.关.ToString();
                    break;
                default:
                    break;
            }


            switch (splitdata[9])
            {
                case "0x00":
                    this.AirControl.conSlienceMode = FirstFunctionCategories_C.SilenceMode.静音.ToString();
                    break;
                case "0x01":
                    this.AirControl.conSlienceMode = FirstFunctionCategories_C.SilenceMode.自动静音.ToString();
                    break;
                case "0x02":
                    this.AirControl.conSlienceMode = FirstFunctionCategories_C.SilenceMode.关.ToString();
                    break;
                default:
                    break;
            }

            this.AirControl.conTemperature = (Convert.ToInt32(splitdata[10], 16)).ToString();

            switch (splitdata[11])
            {
                case "0x00":
                    this.AirControl.conSleepMode = FirstFunctionCategories_C.SleepMode.一小时.ToString();
                    break;
                case "0x01":
                    this.AirControl.conSleepMode = FirstFunctionCategories_C.SleepMode.二小时.ToString();
                    break;
                case "0x02":
                    this.AirControl.conSleepMode = FirstFunctionCategories_C.SleepMode.三小时.ToString();
                    break;
                case "0x03":
                    this.AirControl.conSleepMode = FirstFunctionCategories_C.SleepMode.关.ToString();
                    break;
                default:
                    break;
            }

            switch (splitdata[12])
            {
                case "0x00":
                    this.AirControl.conTimeMode = FirstFunctionCategories_C.TimerMode.一小时.ToString();
                    break;
                case "0x01":
                    this.AirControl.conTimeMode = FirstFunctionCategories_C.TimerMode.二小时.ToString();
                    break;
                case "0x02":
                    this.AirControl.conTimeMode = FirstFunctionCategories_C.TimerMode.三小时.ToString();
                    break;
                case "0x03":
                    this.AirControl.conTimeMode = FirstFunctionCategories_C.TimerMode.关.ToString();
                    break;
                default:
                    break;
            }

             switch (splitdata[13])
            {
                case "0x00":
                    this.AirControl.conUpDownWindsweep = FirstFunctionCategories_C.VerWindSweep.开.ToString();
                    break;
                case "0x01":
                    this.AirControl.conUpDownWindsweep = FirstFunctionCategories_C.VerWindSweep.关.ToString();
                    break;
                default:
                    break;
            }
            // 0     1       2       3     4      5         6      7     8            9      10    11      12      13       14     15    16     17
            // 字头 后继数据 设备数量 地址 设备状态 超强模式 工作模式 风强度 健康换气模式 静音模式 温度 睡眠模式 定时模式 上下扫风 左右扫风 灯光 温度显示 校验和
            //0xa5  0x00      0x0a   0x01  0x01   0x01    0x00     0x00   0x00        0x00   0x0b  0x01    0x00    0x00    0x01    0x00  0x01   0x00
            switch (splitdata[14])
            {
                case "0x00":
                    this.AirControl.conLeftRigetWindsweep = FirstFunctionCategories_C.HorWindSweep.开.ToString();
                    break;
                case "0x01":
                    this.AirControl.conLeftRigetWindsweep = FirstFunctionCategories_C.HorWindSweep.关.ToString();
                    break;
                default:
                    break;
            }
            // 0     1       2       3     4      5         6      7     8            9     10     11      12      13       14     15    16     17
            // 字头 后继数据 设备数量 地址 设备状态 超强模式 工作模式 风强度 健康换气模式 静音模式 温度 睡眠模式 定时模式 上下扫风 左右扫风 灯光 温度显示 校验和
            //0xa5  0x00      0x0a   0x01  0x01   0x01    0x00     0x00   0x00        0x00   0x0b  0x01    0x00    0x00    0x01    0x00  0x01   0x00
            switch (splitdata[15])
            {
                case "0x00":
                    this.AirControl.conLight = FirstFunctionCategories_C.Light.开.ToString();
                    break;
                case "0x01":
                    this.AirControl.conLight = FirstFunctionCategories_C.Light.关.ToString();
                    break;
                default:
                    break;
            }
            switch (splitdata[16])
            {
                case "0x00":
                    this.AirControl.conTemperatureDdisplay = FirstFunctionCategories_C.TemperatureDisplayMode.开.ToString();
                    break;
                case "0x01":
                    this.AirControl.conTemperatureDdisplay = FirstFunctionCategories_C.TemperatureDisplayMode.关.ToString();
                    break;
                default:
                    break;
            }
            switch (splitdata[17])
            {
               
                case "0x00":
                    this.AirControl.conDry= FirstFunctionCategories_C.DryMode.开.ToString();
                    break;
                case "0x01":
                    this.AirControl.conDry = FirstFunctionCategories_C.DryMode.关.ToString();
                    break;
                default:
                    break;
            }
        }

        public void SendData(string data)
        {


            //  MessageBox.Show(data);


            this.SerialPort.Write(data);

        }

        public void ToControlDispaly()
        {
            this.AirControlList.GetAirControl(AircontrolIndexClass.CurrentAirControlIndex);
        }

      
        private void LoopSimpleBatchSend(string commandname,string commandcontent)
        {
            

            string data = null;
            for (int i = 0; i <this.AirControlList.GetCount(); i++)
            {
                data = this.AirControlList.GetAirControl(i).conAddr + " " + commandname + " " + commandcontent;
                SendData(data);
               
            }

            
        
        }

        public void SimpleBetachParser(string commandName, string commandContent)
        {
            string parseCommandName = null;
            string parseCommandContent = null;
          //  MessageBox.Show(commandName);
            switch (commandName)
            {
                case "driveStateCbox":
                    parseCommandName = "0x00";
                    switch (commandContent)
                    {
                        case "开":
                            parseCommandContent = "0x00";
                            break;
                        case "关":
                            parseCommandContent = "0x01";
                            break;
                        default:
                            break;
                    }
                    break;
                case "superPowerCbox":
                    parseCommandName = "0x01";
                    switch (commandContent)
                    {
                        case "开":
                            parseCommandContent = "0x00";
                            break;
                        case "关":
                            parseCommandContent = "0x01";
                            break;
                        default:
                            break;
                    }
                    break;
                case "workmodelCbox":
                    parseCommandName = "0x02";
                    switch (commandContent)
                    {
                        case "自动":
                            parseCommandContent = "0x00";
                            break;
                        case "制热":
                            parseCommandContent = "0x01";
                            break;
                        case "制冷":
                            parseCommandContent = "0x02";
                            break;
                        case "吹风":
                            parseCommandContent = "0x03";
                            break;
                        case "除湿":
                            parseCommandContent = "0x04";
                            break;
                        default:
                            break;
                    }
                    break;
                case "windpowerCbox":
                    parseCommandName = "0x03";
                    switch (commandContent)
                    {
                        case "一级":
                            parseCommandContent = "0x00";
                            break;
                        case "二级":
                            parseCommandContent = "0x01";
                            break;
                        case "三级":
                            parseCommandContent = "0x02";
                            break;
                        default:
                            break;
                    }
                    break;
                case "heathmodeCbox":
                    parseCommandName = "0x04";
                    switch (commandContent)
                    {
                        case "健康":
                            parseCommandContent = "0x00";
                            break;
                        case "换气":
                            parseCommandContent = "0x01";
                            break;
                        case "健康换气":
                            parseCommandContent = "0x02";
                            break;
                        case "关":
                            parseCommandContent = "0x03";
                            break;
                        default:
                            break;
                    }
                    break;
                case "sliencemodeCbox":
                    parseCommandName = "0x05";
                    switch (commandContent)
                    {
                        case "静音":
                            parseCommandContent = "0x00";
                            break;
                        case "自动静音":
                            parseCommandContent = "0x01";
                            break;
                        case "关":
                            parseCommandContent = "0x02";
                            break;
                        default:
                            break;
                    }
                    break;
                case "settemperature":
                    parseCommandName = "0x06";
                    parseCommandContent = commandContent;
                    break;
                case "sleepmodeCbox":
                    parseCommandName = "0x07";
                    switch (commandContent)
                    {
                        case "一小时":
                            parseCommandContent = "0x00";
                            break;
                        case "二小时":
                            parseCommandContent = "0x01";
                            break;
                        case "三小时":
                            parseCommandContent = "0x02";
                            break;
                        case "关":
                            parseCommandContent = "0x03";
                            break;
                        default:
                            break;
                    }
                    break;
                case "timeemodeCbox":
                    parseCommandName = "0x08";
                    switch (commandContent)
                    {
                        case "一小时":
                            parseCommandContent = "0x00";
                            break;
                        case "二小时":
                            parseCommandContent = "0x01";
                            break;
                        case "三小时":
                            parseCommandContent = "0x02";
                            break;
                        case "关":
                            parseCommandContent = "0x03";
                            break;
                        default:
                            break;
                    }
                    break;
                case "updownwindemodeCbox":
                    parseCommandName = "0x09";
                    switch (commandContent)
                    {
                        case "开":
                            parseCommandContent = "0x00";
                            break;
                        case "关":
                            parseCommandContent = "0x01";
                            break;
                        default:
                            break;
                    }
                    break;
                case "leftrightwindmodeCbox":
                    parseCommandName = "0x0a";
                    switch (commandContent)
                    {
                        case "开":
                            parseCommandContent = "0x00";
                            break;
                        case "关":
                            parseCommandContent = "0x01";
                            break;
                        default:
                            break;
                    }
                    break;
                case "lightCbox":
                    parseCommandName = "0x0b";
                    switch (commandContent)
                    {
                        case "开":
                            parseCommandContent = "0x00";
                            break;
                        case "关":
                            parseCommandContent = "0x01";
                            break;
                        default:
                            break;
                    }
                    break;
                case "temperaturedisplayCbox":
                    parseCommandName = "0x0c";
                    switch (commandContent)
                    {
                        case "开":
                            parseCommandContent = "0x00";
                            break;
                        case "关":
                            parseCommandContent = "0x01";
                            break;
                        default:
                            break;
                    }
                    break;
                case "dryModeCbox":
                    parseCommandName = "0x0d";
                    switch (commandContent)
                    {
                        case "开":
                            parseCommandContent = "0x00";
                            break;
                        case "关":
                            parseCommandContent = "0x01";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            if (!String.IsNullOrEmpty(parseCommandName)&&!String.IsNullOrEmpty(parseCommandContent))
            {

               
                LoopSimpleBatchSend(parseCommandName, parseCommandContent);
             
            }
        }

       

        public event ParseDataChangedEventHandler ParseDataChangeEvent;
     
    }
}
