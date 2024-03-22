using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkishDraughts
{
    internal class PlayerClass
    {
        String name;
        public PlayerClass(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return this.name;
        }
        public void setName(String name)
        {
            this.name = name;
        }
    }
}
