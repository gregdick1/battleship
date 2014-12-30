using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Board
    {
        /*
         * Values per space
         * 0 - Nothing has happened in this space
         * 1 - Aircraft carrier occupies this space but has not been hit
         * 2 - Battleship occupies this space but has not been hit
         * 3 - Submarine occupies this space but has not been hit
         * 4 - Cruiser occupies this space but has not been hit
         * 5 - Destroyer occupies this space but has not been hit
         * 6 - Hit Ship
         * 7 - Shot and miss
         * */
        private int[][] _board;

        public Board()
        {
            _board = new int[10][];
            for (int i = 0; i < 10; i++)
            {
                _board[i] = new int[10];
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _board[i][j] = 0;
                }
            }
        }

        public Board HideShips()
        {
            var newBoard = new Board();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var space = _board[i][j];
                    if (space <= 5)
                    {
                        space = 0;
                    }
                    newBoard._board[i][j] = space;
                }
            }
            return newBoard;
        }

        public Move ApplyMove(Coordinate c)
        {
            var remainingShips = RemainingShips();
            var space = _board[c.GetX()][c.GetY()];
            if (space == 0)
            {
                _board[c.GetX()][c.GetY()] = 7;
            }
            else if (space > 0 && space <= 5)
            {
                _board[c.GetX()][c.GetY()] = 6;
            }
            var move = new Move
            {
                Coordinate = c,
                IsHit = space > 0 && space <= 5,
                IsSunk = RemainingShips().Count < remainingShips.Count
            };
            return move;
        }

        public List<int> RemainingShips()
        {
            var remaining = new HashSet<int>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    var space = _board[i][j];
                    if (space > 0 && space <= 5)
                    {
                        remaining.Add(space);
                    }
                }
            }
            var list = new List<int>(remaining);
            list.Sort();
            return list;
        }

        private int GetShipSize(int ship)
        {
            switch (ship)
            {
                case 1:
                    return 5;
                case 2:
                    return 4;
                case 3:
                case 4:
                    return 3;
                case 5:
                    return 2;
                default:
                    throw new ArgumentException("Unknown ship");
            }
        }

        public void PlaceShip(CoordinatePair c, int ship)
        {
            var shipSize = GetShipSize(ship);
            if (ValidateCoordinatesForShip(c, shipSize))
            {
                var ax = c.GetOne().GetX();
                var ay = c.GetOne().GetY();

                var bx = c.GetTwo().GetX();
                var by = c.GetTwo().GetY();

                if (ax == bx)
                {
                    for (int i = Math.Min(ay, by); i <= Math.Max(ay, by); i++)
                    {
                        _board[ax][i] = ship;
                    }
                }
                if (ay == by)
                {
                    for (int i = Math.Min(ax, bx); i <= Math.Max(ax, bx); i++)
                    {
                        _board[i][ay] = ship;
                    }
                }    
            }
        }

        public bool ValidateCoordinatesForShip(CoordinatePair c, int shipSize)
        {
            shipSize = shipSize - 1; //coordinates are inclusive on both ends so shipSize will be off by one when comparing differences
            var ax = c.GetOne().GetX();
            var ay = c.GetOne().GetY();

            var bx = c.GetTwo().GetX();
            var by = c.GetTwo().GetY();

            if (ax != bx && ay != by)
            {
                return false;
            }
            if (ax == bx)
            {
                if (Math.Abs(ay - by) != shipSize)
                {
                    return false;
                }
                for (int i = Math.Min(ay, by); i <= Math.Max(ay, by); i++)
                {
                    if (_board[ax][i] != 0)
                    {
                        return false;
                    }
                }
            }
            if (ay == by)
            {
                if (Math.Abs(ax - bx) != shipSize)
                {
                    return false;
                }
                for (int i = Math.Min(ax, bx); i <= Math.Max(ax, bx); i++)
                {
                    if (_board[i][ay] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sb.Append("[").Append(_board[j][i]).Append("]");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }
    }
}
