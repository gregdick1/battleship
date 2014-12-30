using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Move
    {
        public Coordinate Coordinate { get; set; }
        public bool IsHit { get; set; }
        public bool IsSunk { get; set; }

        public Move()
        {
            
        }

        public Move(Move toCopy)
        {
            Coordinate = new Coordinate(toCopy.Coordinate);
            IsHit = toCopy.IsHit;
            IsSunk = toCopy.IsSunk;
        }
    }
}
