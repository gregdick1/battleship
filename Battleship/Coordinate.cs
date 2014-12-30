using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Battleship
{
    public class Coordinate
    {
        private int _x;
        private int _y;

        /// <summary>
        /// A coordinate on the board. Must be created with a string that starts with a letter A-J and then a number 0-9.
        /// Examples of coordinates would be "A0", "C4", "J9", etc.
        /// </summary>
        public Coordinate(string coord)
        {
            if(coord == null || coord.Length != 2)
            {
                throw new ArgumentException("Invliad coordinate input");
            }
            var x = coord.Substring(0, 1).ToLower();
            var y = coord.Substring(1, 1);
            if (!Regex.IsMatch(x, "[a-j]") || !Regex.IsMatch(y, "[0-9]"))
            {
                throw new ArgumentException("Invliad coordinate input");
            }
            _x = x[0] - 97;
            _y = y[0] - 48;
        }

        public Coordinate(int x, int y)
        {
            if (x < 0 || x > 9 || y < 0 || y > 9)
            {
                throw new ArgumentException("Invalid coordinate input");
            }
            _x = x;
            _y = y;
        }

        public Coordinate(Coordinate toCopy)
        {
            _x = toCopy.GetX();
            _y = toCopy.GetY();
        }

        public override string ToString()
        {
            return ((char) (_x + 97)).ToString() + ((char) (_y + 48)).ToString();
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }
    }
}
