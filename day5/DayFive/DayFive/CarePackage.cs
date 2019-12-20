using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace DayFive
{
    public class CarePackage
    {
        IDictionary<Tuple<int, int>, GameTiles> _board;
        int _score;

        public int Score => _score;
        public int CountBlockTiles => _board.Where(kvp => kvp.Value == GameTiles.Block).Count();
        public CarePackage() {
            _board = new Dictionary<Tuple<int, int>, GameTiles>();
            _score = 0;
        }

        public void SetUp(IntCodeCompiler d13)
        {
            d13.Calculate();


            while (d13.OutputQueue.Count >= 3)
            {
                int x = (int)d13.OutputQueue.Dequeue();
                int y = (int)d13.OutputQueue.Dequeue();
                int t = (int)d13.OutputQueue.Dequeue();
                _board.Add(new Tuple<int, int>(x, y), (GameTiles)t);
            }
        }

        public int Play(IntCodeCompiler d13)
        {
            int blocks = 1;
            d13.Calculate();
            while (d13.State != CompilerState.Halted || blocks != 0)
            {
                if (d13.State == CompilerState.PausedWaitingForInput)
                {
                    while (d13.OutputQueue.Count >= 3)
                    {
                        int x = (int)d13.OutputQueue.Dequeue();
                        int y = (int)d13.OutputQueue.Dequeue();
                        int t = (int)d13.OutputQueue.Dequeue();
                        if (x == -1 && y == 0)
                        { _score = t; }
                        else
                        {
                            var p = new Tuple<int, int>(x, y);
                            if (_board.ContainsKey(p))
                                _board[p] = (GameTiles)t;
                            else
                                _board.Add(new Tuple<int, int>(x, y), (GameTiles)t);
                        }
                    }
                    blocks = OutputBoard();
                }
                if (blocks == 0)
                    break;
                Console.WriteLine("score: {0}, {1} blocks remain.", Score, blocks);
                Console.Write("input > ");
                var i = 0; //  Convert.ToInt64(Console.ReadLine());
                System.Threading.Thread.Sleep(100);
                d13.ProvideInput(i);
                d13.Calculate();
                if (d13.State == CompilerState.Halted && blocks > 0)
                    d13.ResetAndCalculate();
            }

            return _score;
        }

        int OutputBoard()
        {
            int maxX = _board.Select(p => p.Key.Item1).Max();
            int maxY = _board.Select(p => p.Key.Item2).Max();
            int blocks = 0;
            for(int y = 0; y <= maxY; ++y)
            {
                StringBuilder sb = new StringBuilder();
                for(int x = 0;  x<= maxX; ++x)
                {
                    var p = new Tuple<int, int>(x, y);
                    if (_board.ContainsKey(p))
                    {
                        switch (_board[p])
                        {
                            case (GameTiles.Ball):
                                sb.Append('o');
                                break;
                            case GameTiles.Block:
                                sb.Append('X');
                                ++blocks;
                                break;
                            case GameTiles.Wall:
                                sb.Append('|');
                                break;
                            case GameTiles.HorizontalPaddle:
                                sb.Append('_');
                                break;
                            default:
                                sb.Append(' ');
                                break;
                        }
                    }
                    else
                        sb.Append(' ');
                }
                Console.WriteLine(sb.ToString());
            }
            return blocks;
        }
    }
}
