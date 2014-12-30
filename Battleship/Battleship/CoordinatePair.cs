using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class CoordinatePair
    {
        private Coordinate _one;
        private Coordinate _two;

        public CoordinatePair(Coordinate one, Coordinate two)
        {
            if (one == null || two == null)
            {
                throw new ArgumentException("Cannot have null coordinates.");
            }
            _one = one;
            _two = two;
        }

        public CoordinatePair(string one, string two)
        {
            _one = new Coordinate(one);
            _two = new Coordinate(two);
        }

        public Coordinate GetOne()
        {
            return _one;
        }

        public Coordinate GetTwo()
        {
            return _two;
        }
    }
}
