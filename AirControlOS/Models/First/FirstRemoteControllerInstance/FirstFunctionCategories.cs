using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirControlOS.Models.First.FirstRemoteControllerInstance
{
   public static class FirstFunctionCategories
    {
        public enum SuperPowerMode
        {
            On,Off
        }
        public enum DriveState
        {
            On,Off
        }
        public enum WorkModel
        {
            Auto,Heating,Refrigeration,Blow,Dehumidification
        }
        public enum WindPowerMode
        {
            One,Two,Three,Four,Five
        }
        public enum HeathAndAirChangeMode
        {
            OnlyHeath,OnlyAirChange,HeathAndAirChange,Off
        }
        public enum TemperatureDisplayMode
        {
            On,Off
        }
       public enum SilenceMode
       {
           Silence,AutoSilence,Off
       }
        public enum SetTemperatureMode
        {
            Add,Subtract
        }
        public enum DryMode
        {
            On,Off
        }

        public enum SleepMode
        {
            One,Two,Three,Off
        }

        public enum TimerMode
        {
            One, Two, Three, Off
        }

        public enum HorWindSweep
        {
            On,Off
        }
        public enum VerWindSweep
        {
            On, Off
        }
        public enum Light
        {
           On,Off
        }
    }
}
