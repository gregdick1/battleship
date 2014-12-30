using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Strategy
    {
        /// <summary>
        /// Come up with your next move.
        /// </summary>
        public abstract Coordinate GetNextMove(NextMoveContext context);

        /// <summary>
        /// Aircraft must occupy five spaces
        /// </summary>
        public abstract CoordinatePair GetAircraftCarrierPosition();

        /// <summary>
        /// Battleship must occupy four spaces
        /// </summary>
        public abstract CoordinatePair GetBattleshipPosition();

        /// <summary>
        /// Submarine must occupy three spaces
        /// </summary>
        public abstract CoordinatePair GetSubmarinePosition();

        /// <summary>
        /// Cruiser must occupy three spaces
        /// </summary>
        public abstract CoordinatePair GetCruiserPosition();

        /// <summary>
        /// Destroyer must occupy two spaces
        /// </summary>
        public abstract CoordinatePair GetDestroyerPosition();

        public Board GetBoard()
        {
            var board = new Board();
            if (board.ValidateCoordinatesForShip(GetAircraftCarrierPosition(), 5))
            {
                board.PlaceShip(GetAircraftCarrierPosition(), 1);
            }
            else
            {
                throw new InvalidOperationException("Your strategy has an invalid placement for the aircraft carrier.");
            }
            if (board.ValidateCoordinatesForShip(GetBattleshipPosition(), 4))
            {
                board.PlaceShip(GetBattleshipPosition(), 2);
            }
            else
            {
                throw new InvalidOperationException("Your strategy has an invalid placement for the battleship.");
            }
            if (board.ValidateCoordinatesForShip(GetSubmarinePosition(), 3))
            {
                board.PlaceShip(GetSubmarinePosition(), 3);
            }
            else
            {
                throw new InvalidOperationException("Your strategy has an invalid placement for the submarine.");
            }
            if (board.ValidateCoordinatesForShip(GetCruiserPosition(), 3))
            {
                board.PlaceShip(GetCruiserPosition(), 4);
            }
            else
            {
                throw new InvalidOperationException("Your strategy has an invalid placement for the cruiser.");
            }
            if (board.ValidateCoordinatesForShip(GetDestroyerPosition(), 2))
            {
                board.PlaceShip(GetDestroyerPosition(), 5);
            }
            else
            {
                throw new InvalidOperationException("Your strategy has an invalid placement for the destroyer.");
            }
            return board;
        }
    }
}
