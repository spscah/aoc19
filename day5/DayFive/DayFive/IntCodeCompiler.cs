using System;
using System.Collections.Generic;

namespace DayFive
{
    enum CompilerState
    {
        PausedWaitingForInput, 
        Halted,
        Initialised,
        Poised,
        Running

    }
    public class IntCodeCompiler
    {       

        readonly Queue<int> _inputs = null;
        int _lastOutput;
        int _currentinstruction;
        CompilerState _state;
        readonly string _name;
        readonly bool _useConsoleInput;
        readonly IList<int> _sourceCode;

        internal CompilerState State => _state;
        public int LastOutput => _lastOutput;
        public IntCodeCompiler(string name, IList<int> code, bool useConsoleInput)
        {
            _name = name;
            _currentinstruction = 0;
            _state = CompilerState.Initialised;
            _useConsoleInput = useConsoleInput;
            _sourceCode = code;
        }
        public IntCodeCompiler(string name, IList<int> code, Queue<int> inputs) : this(name, code, false)
        {
            _inputs = inputs;
        }

        public IntCodeCompiler(IList<int> code, Queue<int> inputs) : this(string.Empty, code, inputs)
        { }

        public void ProvideInput(int input)
        {
            if (_state != CompilerState.PausedWaitingForInput)
                throw new InvalidOperationException("not expecting input at this time");
            Opcode opcode = new Opcode(_sourceCode[_currentinstruction]);
            int location = _currentinstruction + 1;
            if (opcode.Modes[0] == ParameterMode.Position)
                location = _sourceCode[location];
            _sourceCode[location] = input;
            _currentinstruction += opcode.Jump;
            _state = CompilerState.Poised;
        }

        public int? Calculate()
        {
            if(_state != CompilerState.Poised && _state != CompilerState.Initialised)
                throw new InvalidOperationException("not expecting to be run at this time");

            while (_sourceCode[_currentinstruction] != 99)
            {
                Opcode opcode = new Opcode(_sourceCode[_currentinstruction]);
                if (opcode.Code == CodeMnemonics.Add||opcode.Code==CodeMnemonics.Multiply || opcode.Code == CodeMnemonics.LessThan || opcode.Code == CodeMnemonics.Equals)
                {
                    int a = _sourceCode[_currentinstruction + 1];
                    if (opcode.Modes[0] == ParameterMode.Position)
                        a = _sourceCode[a];

                    int b = _sourceCode[_currentinstruction + 2];
                    if (opcode.Modes[1] == ParameterMode.Position)
                        b = _sourceCode[b];

                    int location = _currentinstruction + 3;
                    if (opcode.Modes[2] == ParameterMode.Position)
                        location = _sourceCode[location];

                    if (opcode.Code == CodeMnemonics.Add)
                        _sourceCode[location] = a + b;
                    if (opcode.Code == CodeMnemonics.Multiply)
                        _sourceCode[location] = a * b;
                    if (opcode.Code == CodeMnemonics.Equals)
                    {
                        _sourceCode[location] = (a == b) ? 1 : 0;
                    }
                    if (opcode.Code == CodeMnemonics.LessThan)
                    {
                        _sourceCode[location] = (a < b) ? 1 : 0;
                    }
                }
                if (opcode.Code == CodeMnemonics.Input)
                {
                    int location = _currentinstruction + 1;
                    if (opcode.Modes[0] == ParameterMode.Position)
                        location = _sourceCode[location];
                    if (_inputs != null && _inputs.Count > 0)
                        _sourceCode[location] = _inputs.Dequeue();
                    else
                    {
                        if (_useConsoleInput)
                        {
                            Console.Write("input > ");
                            _sourceCode[location] = Convert.ToInt32(Console.ReadLine());
                        } else
                        {
                            _state = CompilerState.PausedWaitingForInput;
                            return null;
                        }
                        
                    }
                }
                if (opcode.Code == CodeMnemonics.Output)
                {
                    int location = _currentinstruction + 1;
                    if (opcode.Modes[0] == ParameterMode.Position)
                        location = _sourceCode[location];
                    Output(_sourceCode[location]);

                }
                if(opcode.Code == CodeMnemonics.JumpIfTrue || opcode.Code == CodeMnemonics.JumpIfFalse)
                {
                    int testvalue = _sourceCode[_currentinstruction + 1];
                    if (opcode.Modes[0] == ParameterMode.Position)
                        testvalue = _sourceCode[testvalue];
                    int location = _sourceCode[_currentinstruction + 2];
                    if (opcode.Modes[1] == ParameterMode.Position)
                        location = _sourceCode[location];

                    if ((opcode.Code == CodeMnemonics.JumpIfTrue && testvalue > 0) || (opcode.Code == CodeMnemonics.JumpIfFalse && testvalue == 0)) 
                    {
                        _currentinstruction = location;
                        opcode.SetJumpToZero();
                    }
                }

                _currentinstruction += opcode.Jump;
            }
            _state = CompilerState.Halted;
            return _sourceCode[0];
        }
        void Output(int i)
        {
            _lastOutput = i;
            Console.WriteLine(i);        
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", _name, _currentinstruction, _state, _lastOutput);
        }
    }
}
