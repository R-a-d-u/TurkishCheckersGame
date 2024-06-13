using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkishDraughts
{
    internal class PlayerTurnClass
    {
        private bool playerTurn;
        public PlayerTurnClass(bool playerTurn)
        {
            this.playerTurn = playerTurn;
        }
        public bool getPlayerTurn()
        {
            return playerTurn;
        }
        public void setPlayerTurn(bool playerTurn)
        {
            this.playerTurn = playerTurn;
        }
    }
}
