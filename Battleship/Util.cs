using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Util
    {
        private static Random rng = new Random();

        public static List<CoordinatePair> GetPossibleLocations(Board board, int shipSize)
        {
            var list = new List<CoordinatePair>();
            for (int y = 0; y < 10 - shipSize; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    var cp = new CoordinatePair(new Coordinate(x, y), new Coordinate(x, y + shipSize - 1));
                    if (board.ValidateCoordinatesForShip(cp, shipSize))
                    {
                        list.Add(cp);
                    }
                }
            }
            for (int x = 0; x < 10 - shipSize; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    var cp = new CoordinatePair(new Coordinate(x, y), new Coordinate(x + shipSize - 1, y));
                    if (board.ValidateCoordinatesForShip(cp, shipSize))
                    {
                        list.Add(cp);
                    }
                }
            }
            return list;
        }

        public static Board GetBoardWithRandomShipLocations()
        {
            var board = new Board();

            var locations = GetPossibleLocations(board, 5);
            board.PlaceShip(locations[rng.Next(locations.Count)], 1);

            locations = GetPossibleLocations(board, 4);
            board.PlaceShip(locations[rng.Next(locations.Count)], 2);

            locations = GetPossibleLocations(board, 3);
            board.PlaceShip(locations[rng.Next(locations.Count)], 3);

            locations = GetPossibleLocations(board, 3);
            board.PlaceShip(locations[rng.Next(locations.Count)], 4);

            locations = GetPossibleLocations(board, 2);
            board.PlaceShip(locations[rng.Next(locations.Count)], 5);

            return board;
        }
    }
}
