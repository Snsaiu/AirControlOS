using AirControlOS.Models.AirControlFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.MCU
{
    class MCU_E
    {

       public List<string> Alist { get; set; }
        public Random rd { get; set; }
        public MCU_E()
        {
            Alist = new List<string>();
            rd = new Random();
            for (int i = 0; i < 10; i++)
            {
                // 0     1       2       3     4      5         6      7     8            9    10     11      12      13       14     15    16        17          18
                // 字头 后继数据 设备数量 地址 设备状态 超强模式 工作模式 风强度 健康换气模式 静音模式 温度 睡眠模式 定时模式 上下扫风 左右扫风 灯光 温度显示  干燥模式   校验和
                //0xa5  0x00      0x0a   0x01  0x01   0x01    0x00     0x00   0x00        0x00   0x0b  0x01    0x00    0x00    0x01    0x00  0x01     0x00         0x00
                string getdata = "0xa5 0x00 0x0a 0x0" + rd.Next(0, 5).ToString() + " 0x0"+rd.Next(0,2).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 5).ToString() + " 0x0" + rd.Next(0, 5).ToString() + " 0x0" + rd.Next(0, 3).ToString() + " 0x00 0x0" + rd.Next(10, 50).ToString() + " 0x0" + rd.Next(0, 5).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0" + rd.Next(0, 2).ToString() + " 0x0"+rd.Next(0,2).ToString() + " 0x00";
                Alist.Add(getdata);
            }
        }

        public void PcObtainMcu(string command)
        {
            string[] splitcommand = command.Split(new char[] { ' ' });
            if (splitcommand[0] == "0xff" && splitcommand[1]=="0xff" && splitcommand[2] == "0xff" && splitcommand[3]=="0xff" && splitcommand[3] == "0xff")
            {
            
            }

      

        }

        public void GetData(string data)
        {

        }
    }
}
