using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class NextMoveContext
    {
        public Board Board { get; set; }
        public List<Move> PreviousMoves { get; set; }
        public Move LastMove { get; set; }
        //1 = aircraft carrier, 2 = battleship, 3 = submarine, 4 = cruiser, 5 = destroyer
        public List<int> RemainingShips { get; set; } 
    }
}
