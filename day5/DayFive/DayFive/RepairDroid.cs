using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace DayFive
{
    public class RepairDroid
    {
        IDictionary<Tuple<int, int>, char> _board;

        public RepairDroid()
        {
            _board = new Dictionary<Tuple<int, int>, char>();
        }

        public int FillWithOxygen()
        {
            OutputBoard();
            int minutes = 0;
            while(_board.Where(kvp => kvp.Value == '.').Count() > 0)
            {
                var oRich = _board.Where(kvp => kvp.Value == 'O').Select(kvp => kvp.Key).ToList();
                foreach (Tuple<int, int> c in oRich)
                {                    
                    Tuple<int, int> up = new Tuple<int, int>(c.Item1, c.Item2 + 1);
                    Tuple<int, int> down = new Tuple<int, int>(c.Item1, c.Item2 - 1);
                    Tuple<int, int> left = new Tuple<int, int>(c.Item1-1, c.Item2);
                    Tuple<int, int> right = new Tuple<int, int>(c.Item1+1, c.Item2);
                    IList<Tuple<int, int>> directions = new List<Tuple<int, int>> { up, down, left, right };
                    foreach (var d in directions)
                        if (_board.ContainsKey(d) && _board[d] == '.')
                            _board[d] = 'O';
                }
                ++minutes;
                OutputBoard();
                Console.WriteLine(minutes);
            }

            return minutes;
        }

        public int MapArea(IntCodeCompiler d15)
        {
            Tuple<int, int> location = new Tuple<int, int>(0, 0);
            Stack<Tuple<int, int, int, bool>> moves = new Stack<Tuple<int, int, int, bool>>();
            for (int i = 4; i >= 1; --i)
                moves.Push(new Tuple<int, int, int, bool>(0, 0, i, false));
            // the visited dictionary should have the minimum step count 
            IDictionary<Tuple<int, int>, int?> visited = new Dictionary<Tuple<int, int>, int?>
            {
                [location] = 0
            };
            _board[location] = 'D';
            d15.Calculate();
            Tuple<int, int> oxygen = null;
            while (moves.Count > 0)
            {
                bool success = false;
                Tuple<int, int> nextLocation = null;
                Tuple<int, int, int, bool> reverseMove = null;
                int i = 0;
                int r = 0;
                bool reversedMove = false;
                while (!success) 
                {
                    if (moves.Count == 0)
                        return visited[oxygen].Value;
                    var move = moves.Pop();
                    if (move.Item1 != location.Item1 || move.Item2 != location.Item2)
                        throw new InvalidOperationException("I'm not where I expected to be");
                    // Console.Write("input (1-4) > ");
                    i = move.Item3; // Convert.ToInt32(Console.ReadLine());
                    int x = location.Item1;
                    int y = location.Item2;


                    switch (i)
                    {
                        case 1: y++; r = 2; break;
                        case 2: y--; r = 1; break;
                        case 3: x++; r = 4; break;
                        case 4: x--; r = 3; break;
                    }
                    

                    // create the next location and the reverse move, then add it if we make the move 

                    nextLocation = new Tuple<int, int>(x, y);
                    reverseMove = new Tuple<int, int, int, bool>(x, y, r, true);
                    reversedMove = move.Item4;
                    // have we been here before? don't check if it's the reverse move 
                    if (visited.ContainsKey(nextLocation) && !move.Item4)
                    {
                        if (visited[nextLocation] == -1)
                        {
                            if (moves.Count == 0)
                                return visited[oxygen].Value;
                            continue;
                        }
                        if (visited[nextLocation] > visited[location] + 1)
                            visited[nextLocation] = visited[location] + 1;
                    }
                    else 
                        success = true;
                }
                d15.ProvideInput(i);
                d15.Calculate();
                int o = (int)d15.OutputQueue.Dequeue();

                // case 1 or 2 we need to add the reverse move, then add any moves using the stepcount+1
                switch (o)
                {
                    case 0: 
                        _board[nextLocation] = '#';
                        visited[nextLocation] = null;
                        break;
                    case 1:
                    case 2:
                        _board[location] = oxygen != null && location == oxygen ? 'O' : '.'; 
                        _board[nextLocation] = 'D';
                        if (visited.ContainsKey(nextLocation))
                        {
                            if (visited[nextLocation] > visited[location] + 1)
                            {
                                visited[nextLocation] = visited[location] + 1;
                            }
                        }
                        else
                        {
                            visited[nextLocation] = visited[location] + 1;
                        }
                        if (o == 2)
                            oxygen = nextLocation;
                        if (!reversedMove)
                        {
                            moves.Push(reverseMove);
                            for (int d = 1; d <= 4; ++d)
                                if (d != r)
                                    moves.Push(new Tuple<int, int, int, bool>(nextLocation.Item1, nextLocation.Item2, d, false));
                        }
                        location = nextLocation; 
                        break;
                }

                // OutputBoard();

            }
            return visited[oxygen].Value;
        }

        void OutputBoard()
        {
            for (int y = _board.Select(p => p.Key.Item2).Max(); y >= _board.Select(p => p.Key.Item2).Min(); --y)
            {
                StringBuilder sb = new StringBuilder();
                for (int x = _board.Select(p => p.Key.Item1).Min(); x <= _board.Select(p => p.Key.Item1).Max(); ++x)
                {
                    var p = new Tuple<int, int>(x, y);
                    sb.Append(_board.ContainsKey(p) ? _board[p] : ' ');
                }
                Console.WriteLine(sb.ToString());
            }
            Console.WriteLine("- - - - - -\n");

        }
    }
}
