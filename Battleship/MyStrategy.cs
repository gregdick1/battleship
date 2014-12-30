using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class MyStrategy : Strategy
    {
        public override Coordinate GetNextMove(NextMoveContext context)
        {
            /*
             * Sample strategy of simply iterating through all spaces on the board.
             */
            if (context.LastMove == null)
            {
                return new Coordinate("A0");
            }
            var x = context.LastMove.Coordinate.GetX();
            var y = context.LastMove.Coordinate.GetY();
            y++;
            if (y > 9)
            {
                x++;
                y -= 10;
            }
            return new Coordinate(x,y);
        }

        public override CoordinatePair GetAircraftCarrierPosition()
        {
            return new CoordinatePair("B2", "B6");
        }

        public override CoordinatePair GetBattleshipPosition()
        {
            return new CoordinatePair("C3", "F3");
        }

        public override CoordinatePair GetSubmarinePosition()
        {
            return new CoordinatePair("I9", "I7");
        }

        public override CoordinatePair GetCruiserPosition()
        {
            return new CoordinatePair("A9", "A7");
        }

        public override CoordinatePair GetDestroyerPosition()
        {
            return new CoordinatePair("G3", "G4");
        }
    }
}
