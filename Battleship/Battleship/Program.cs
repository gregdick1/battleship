using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var totalMoves = 0;
            for (int i = 0; i < 1000; i++)
            {
                var board = Util.GetBoardWithRandomShipLocations();
                var strategy = new MyStrategy();
                var moves = new List<Move>();
                Move lastMove = null;
                var sanity = 0;
                while (sanity++ < 101) //should never take more than 100 moves
                {
                    var context = new NextMoveContext
                    {
                        Board = board.HideShips(),
                        PreviousMoves = moves.Select(m => new Move(m)).ToList(), //copy list for defense
                        LastMove = lastMove,
                        RemainingShips = board.RemainingShips(),
                    };
                    try
                    {
                        var nextMove = strategy.GetNextMove(context);
                        lastMove = board.ApplyMove(nextMove);
                        moves.Add(lastMove);
                        if (board.RemainingShips().Count == 0)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        throw new Exception("Error running strategy");
                    }
                }
                var thisMoves = moves.Count;
                totalMoves += thisMoves;
            }

            Console.WriteLine((totalMoves / 1000.0));
            Console.ReadKey();
        }

    }
}
