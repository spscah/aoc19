using System;
using System.Collections.Generic;

namespace DayFive
{
    class Program
    {
        static void Main(string[] args)
        {
            RunWithInput(1);
            RunWithInput(5);
            Console.ReadKey();


        }

        static void RunWithInput(int i)
        {
            Console.WriteLine("with {0}",i);
            IList<int> input = new List<int> { 3, 225, 1, 225, 6, 6, 1100, 1, 238, 225, 104, 0, 1101, 9, 90, 224, 1001, 224, -99, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 6, 224, 1, 223, 224, 223, 1102, 26, 62, 225, 1101, 11, 75, 225, 1101, 90, 43, 225, 2, 70, 35, 224, 101, -1716, 224, 224, 4, 224, 1002, 223, 8, 223, 101, 4, 224, 224, 1, 223, 224, 223, 1101, 94, 66, 225, 1102, 65, 89, 225, 101, 53, 144, 224, 101, -134, 224, 224, 4, 224, 1002, 223, 8, 223, 1001, 224, 5, 224, 1, 224, 223, 223, 1102, 16, 32, 224, 101, -512, 224, 224, 4, 224, 102, 8, 223, 223, 101, 5, 224, 224, 1, 224, 223, 223, 1001, 43, 57, 224, 101, -147, 224, 224, 4, 224, 102, 8, 223, 223, 101, 4, 224, 224, 1, 223, 224, 223, 1101, 36, 81, 225, 1002, 39, 9, 224, 1001, 224, -99, 224, 4, 224, 1002, 223, 8, 223, 101, 2, 224, 224, 1, 223, 224, 223, 1, 213, 218, 224, 1001, 224, -98, 224, 4, 224, 102, 8, 223, 223, 101, 2, 224, 224, 1, 224, 223, 223, 102, 21, 74, 224, 101, -1869, 224, 224, 4, 224, 102, 8, 223, 223, 1001, 224, 7, 224, 1, 224, 223, 223, 1101, 25, 15, 225, 1101, 64, 73, 225, 4, 223, 99, 0, 0, 0, 677, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1105, 0, 99999, 1105, 227, 247, 1105, 1, 99999, 1005, 227, 99999, 1005, 0, 256, 1105, 1, 99999, 1106, 227, 99999, 1106, 0, 265, 1105, 1, 99999, 1006, 0, 99999, 1006, 227, 274, 1105, 1, 99999, 1105, 1, 280, 1105, 1, 99999, 1, 225, 225, 225, 1101, 294, 0, 0, 105, 1, 0, 1105, 1, 99999, 1106, 0, 300, 1105, 1, 99999, 1, 225, 225, 225, 1101, 314, 0, 0, 106, 0, 0, 1105, 1, 99999, 1008, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 329, 1001, 223, 1, 223, 1007, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 344, 101, 1, 223, 223, 108, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 359, 101, 1, 223, 223, 108, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 374, 1001, 223, 1, 223, 7, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 389, 1001, 223, 1, 223, 8, 226, 677, 224, 1002, 223, 2, 223, 1006, 224, 404, 1001, 223, 1, 223, 107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 419, 101, 1, 223, 223, 1008, 677, 677, 224, 102, 2, 223, 223, 1006, 224, 434, 101, 1, 223, 223, 1107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 449, 1001, 223, 1, 223, 107, 226, 226, 224, 102, 2, 223, 223, 1006, 224, 464, 101, 1, 223, 223, 107, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 479, 1001, 223, 1, 223, 8, 677, 226, 224, 102, 2, 223, 223, 1005, 224, 494, 1001, 223, 1, 223, 1108, 226, 677, 224, 102, 2, 223, 223, 1006, 224, 509, 101, 1, 223, 223, 1107, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 524, 101, 1, 223, 223, 1008, 226, 226, 224, 1002, 223, 2, 223, 1005, 224, 539, 101, 1, 223, 223, 7, 226, 677, 224, 1002, 223, 2, 223, 1005, 224, 554, 101, 1, 223, 223, 1107, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 569, 1001, 223, 1, 223, 8, 226, 226, 224, 1002, 223, 2, 223, 1006, 224, 584, 101, 1, 223, 223, 1108, 677, 677, 224, 102, 2, 223, 223, 1005, 224, 599, 101, 1, 223, 223, 108, 677, 677, 224, 1002, 223, 2, 223, 1006, 224, 614, 101, 1, 223, 223, 1007, 226, 226, 224, 102, 2, 223, 223, 1005, 224, 629, 1001, 223, 1, 223, 7, 677, 226, 224, 1002, 223, 2, 223, 1005, 224, 644, 101, 1, 223, 223, 1007, 226, 677, 224, 102, 2, 223, 223, 1005, 224, 659, 1001, 223, 1, 223, 1108, 677, 226, 224, 102, 2, 223, 223, 1006, 224, 674, 101, 1, 223, 223, 4, 223, 99, 226 };
            var inputs = new Stack<int>();
            inputs.Push(i);
            var icc = new IntCodeCompiler(inputs);
            icc.Calculate(input);
        }
    }

    enum CodeMnemonics
    {
        Add = 1,
        Multiply = 2,
        Input = 3,
        Output = 4, 
        JumpIfTrue = 5,
        JumpIfFalse = 6,
        LessThan = 7,
        Equals = 8
    }

    enum ParameterMode
    {
        Position = 0,
        Immediate = 1
    }

    class Opcode
    {
        readonly int _value;
        int _jump;
        readonly CodeMnemonics _code;
        readonly IList<ParameterMode> _modes;
        public CodeMnemonics Code => _code;
        public IList<ParameterMode> Modes => _modes;

        public int Jump => _jump;
        public Opcode(int o)
        {
            _value = o;
            _code = (CodeMnemonics)(o % 100);
            _modes = new List<ParameterMode>();
            _modes.Add((ParameterMode)(o % 1000 / 100));
            _modes.Add((ParameterMode)(o % 10000 / 1000));
            _modes.Add((ParameterMode)(o / 10000));

            switch(_code)
            {
                case CodeMnemonics.Input:
                case CodeMnemonics.Output:
                    _jump = 2;
                    break;
                case CodeMnemonics.JumpIfTrue:
                case CodeMnemonics.JumpIfFalse:
                    _jump = 3;
                    break;
                default:
                    _jump = 4;
                    break;
            }
        }

        public void SetJumpToZero()
        {
            _jump = 0;
        }

        public override string ToString()
        {
            return string.Format("[{0}] Code {1} [{2},{3},{4}] += {5}", _value, _code.ToString(), _modes[0].ToString(), _modes[1].ToString(), _modes[2].ToString(), Jump);
        }
    }

    public class IntCodeCompiler
    {
        readonly Stack<int> _inputs;
        private int _lastOutput;

        public int LastOutput => _lastOutput;
        public IntCodeCompiler()
        {
        }
        public IntCodeCompiler(Stack<int> inputs) : this()
        {
            _inputs = inputs;
        }

        public int Calculate(IList<int> memory)
        {
            int index = 0;
            while (memory[index] != 99)
            {
                Opcode opcode = new Opcode(memory[index]);
                if (opcode.Code == CodeMnemonics.Add||opcode.Code==CodeMnemonics.Multiply || opcode.Code == CodeMnemonics.LessThan || opcode.Code == CodeMnemonics.Equals)
                {
                    int a = memory[index + 1];
                    if (opcode.Modes[0] == ParameterMode.Position)
                        a = memory[a];

                    int b = memory[index + 2];
                    if (opcode.Modes[1] == ParameterMode.Position)
                        b = memory[b];

                    int location = index + 3;
                    if (opcode.Modes[2] == ParameterMode.Position)
                        location = memory[location];

                    if (opcode.Code == CodeMnemonics.Add)
                        memory[location] = a + b;
                    if (opcode.Code == CodeMnemonics.Multiply)
                        memory[location] = a * b;
                    if (opcode.Code == CodeMnemonics.Equals)
                    {
                        memory[location] = (a == b) ? 1 : 0;
                    }
                    if (opcode.Code == CodeMnemonics.LessThan)
                    {
                        memory[location] = (a < b) ? 1 : 0;
                    }
                }
                if (opcode.Code == CodeMnemonics.Input)
                {
                    int location = index + 1;
                    if (opcode.Modes[0] == ParameterMode.Position)
                        location = memory[location];
                    if (_inputs != null && _inputs.Count > 0)
                        memory[location] = _inputs.Pop();
                    else
                    {
                        Console.Write("input > ");
                        memory[location] = Convert.ToInt32(Console.ReadLine());
                    }
                }
                if (opcode.Code == CodeMnemonics.Output)
                {
                    int location = index + 1;
                    if (opcode.Modes[0] == ParameterMode.Position)
                        location = memory[location];
                    Output(memory[location]);

                }
                if(opcode.Code == CodeMnemonics.JumpIfTrue || opcode.Code == CodeMnemonics.JumpIfFalse)
                {
                    int testvalue = memory[index + 1];
                    if (opcode.Modes[0] == ParameterMode.Position)
                        testvalue = memory[testvalue];
                    int location = memory[index + 2];
                    if (opcode.Modes[1] == ParameterMode.Position)
                        location = memory[location];

                    if ((opcode.Code == CodeMnemonics.JumpIfTrue && testvalue > 0) || (opcode.Code == CodeMnemonics.JumpIfFalse && testvalue == 0)) 
                    {
                        index = location;
                        opcode.SetJumpToZero();
                    }
                }

                index += opcode.Jump;
            }
            return memory[0];
        }
        void Output(int i)
        {
            _lastOutput = i;
            Console.WriteLine(i);        
        }
    }
}
