using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Timer = System.Windows.Forms.Timer;

namespace TurkishDraughts
{
    internal class TimerClass
    {
        private GameBoardVsRobot gameBoardVsRobot;
        private Timer timer;
        public TimerClass(GameBoardVsRobot gameBoardVsRobot)
        {
            this.gameBoardVsRobot = gameBoardVsRobot;
            timer = new Timer
            {
                Interval = 10000,
                Enabled = false,
        };
            timer.Tick += new System.EventHandler(this.TimerTick);
        }
        private void TimerTick(object sender, EventArgs e)
        {
           
        }
        public Timer getTimer()
        {
            return timer;
        }
        public void startTimer()
        {
            this.timer.Start(); 
        }
        public void stopTimer()
        {
            this.timer.Stop();
        }
    }
}
