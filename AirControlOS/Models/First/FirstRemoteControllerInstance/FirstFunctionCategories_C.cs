using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstRemoteControllerInstance
{
   public static class FirstFunctionCategories_C
    {
        public enum SuperPowerMode
        {
            开, 关
        }
        public enum DriveState
        {
            开, 关
        }
        public enum WorkModel
        {
            自动, 制热, 制冷, 吹风, 除湿
        }
        public enum WindPowerMode
        {
            一级, 二级, 三级, 四级,
        }
        public enum HeathAndAirChangeMode
        {
           健康模式, 换气模式, 健康换气模式, 关
        }
        public enum TemperatureDisplayMode
        {
            开, 关
        }
        public enum SilenceMode
        {
            静音, 自动静音, 关
        }
        public enum SetTemperatureMode
        {
            增加, 减少
        }
        public enum DryMode
        {
            开, 关
        }

        public enum SleepMode
        {
            一小时, 二小时, 三小时, 关
        }

        public enum TimerMode
        {
            一小时, 二小时, 三小时, 关
        }
        public enum HorWindSweep
        {
            开, 关
        }
        public enum VerWindSweep
        {
            开, 关
        }

        public enum Light
        {
            开,关
        }
    }
}
