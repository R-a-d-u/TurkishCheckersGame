using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkishDraughts
{
    internal class PictureBoxPressedClass
    {
        private bool pressed;
        public PictureBoxPressedClass(bool pressed)
        {
            this.pressed = pressed;
        }
        public bool getPressed()
        {
            return pressed;
        }
        public void setPressed(bool pressed)
        {
            this.pressed = pressed;
        }
    }
}
