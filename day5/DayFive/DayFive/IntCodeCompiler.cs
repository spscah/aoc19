using System;
using System.Collections.Generic;
using System.Linq;

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

        readonly Queue<long> _inputs = null;
        long _lastOutput;
        long _currentinstruction;
        CompilerState _state;
        readonly string _name;
        readonly bool _useConsoleInput;
        readonly IDictionary<long,long> _sourceCode;
        readonly Queue<long> _outputQueue;
        long _relativeBaseOffset;

        internal CompilerState State => _state;
        public long LastOutput => _lastOutput;
        public Queue<long> OutputQueue => _outputQueue;
        public IntCodeCompiler(string name, IList<long> code, bool useConsoleInput)
        {
            _name = name;
            _currentinstruction = 0;
            _state = CompilerState.Initialised;
            _useConsoleInput = useConsoleInput;
            _sourceCode = new Dictionary<long, long>();
            for(int i = 0; i < code.Count; ++i)
                _sourceCode.Add((long)i, code[i]);
            _relativeBaseOffset = 0;
            _outputQueue = new Queue<long>();
        }
        public IntCodeCompiler(string name, IList<long> code, Queue<long> inputs) : this(name, code, false)
        {
            _inputs = inputs;
        }

        public IntCodeCompiler(IList<long> code, Queue<long> inputs) : this(string.Empty, code, inputs)
        { }

        public void ProvideInput(long input)
        {
            if (_state != CompilerState.PausedWaitingForInput)
                throw new InvalidOperationException("not expecting input at this time");
            Opcode opcode = new Opcode(GetAndExtendAsNecessary(_currentinstruction));
            long location = _currentinstruction + 1;
            if (opcode.Modes[0] == ParameterMode.Position)
                location = GetAndExtendAsNecessary(location);
            SetAndExtendAsNecessary(location, input);
            _currentinstruction += opcode.Jump;
            _state = CompilerState.Poised;
        }

        public void ResetAndCalculate()
        {
            _currentinstruction = 0;
            _state = CompilerState.Poised;
            Calculate();
        }

        public long? Calculate()
        {
            if(_state != CompilerState.Poised && _state != CompilerState.Initialised)
                throw new InvalidOperationException("not expecting to be run at this time");

            while (GetAndExtendAsNecessary(_currentinstruction) != 99)
            {
                Opcode opcode = new Opcode(GetAndExtendAsNecessary(_currentinstruction));                     
                if (opcode.Code == CodeMnemonics.Add
                    || opcode.Code==CodeMnemonics.Multiply 
                    || opcode.Code == CodeMnemonics.LessThan 
                    || opcode.Code == CodeMnemonics.Equals)
                {
                    long a = GetAndExtendAsNecessary(_currentinstruction + 1);
                    if (opcode.Modes[0] == ParameterMode.Position)
                        a = GetAndExtendAsNecessary(a);
                    if (opcode.Modes[0] == ParameterMode.Relative)
                        a = GetAndExtendAsNecessary(a + _relativeBaseOffset);

                    long b = GetAndExtendAsNecessary(_currentinstruction + 2);
                    if (opcode.Modes[1] == ParameterMode.Position)
                        b = GetAndExtendAsNecessary(b);
                    if (opcode.Modes[1] == ParameterMode.Relative)
                        b = GetAndExtendAsNecessary(b+_relativeBaseOffset);

                    long location = _currentinstruction + 3;
                    if (opcode.Modes[2] == ParameterMode.Position)
                        location = GetAndExtendAsNecessary(location);
                    if (opcode.Modes[2] == ParameterMode.Relative)
                        location = GetAndExtendAsNecessary(location)+_relativeBaseOffset;

                    if (opcode.Code == CodeMnemonics.Add)
                        SetAndExtendAsNecessary(location, a + b);
                    if (opcode.Code == CodeMnemonics.Multiply)
                        SetAndExtendAsNecessary(location, a * b);
                    if (opcode.Code == CodeMnemonics.Equals)
                    {
                        SetAndExtendAsNecessary(location, (a == b) ? 1 : 0);
                    }
                    if (opcode.Code == CodeMnemonics.LessThan)
                    {
                        SetAndExtendAsNecessary(location, (a < b) ? 1 : 0);
                    }
                }
                if (opcode.Code == CodeMnemonics.Input)
                {
                    long location = _currentinstruction + 1;
                    if (opcode.Modes[0] == ParameterMode.Position)
                        location = GetAndExtendAsNecessary(location);
                    if (opcode.Modes[0] == ParameterMode.Relative)
                        location = GetAndExtendAsNecessary(location)+_relativeBaseOffset;
                    if (_inputs != null && _inputs.Count > 0)
                        SetAndExtendAsNecessary(location,  _inputs.Dequeue());
                    else
                    {
                        if (_useConsoleInput)
                        {
                            Console.Write("input > ");
                            SetAndExtendAsNecessary(location, Convert.ToInt64(Console.ReadLine()));
                        } else
                        {
                            _state = CompilerState.PausedWaitingForInput;
                            return null;
                        }
                        
                    }
                }
                if (opcode.Code == CodeMnemonics.Output)
                {
                    long location = _currentinstruction + 1;
                    if (opcode.Modes[0] == ParameterMode.Position)
                        location = GetAndExtendAsNecessary(location);
                    if (opcode.Modes[0] == ParameterMode.Relative)
                        location = GetAndExtendAsNecessary(location)+_relativeBaseOffset;
                    Output(GetAndExtendAsNecessary(location));

                }
                if(opcode.Code == CodeMnemonics.JumpIfTrue || opcode.Code == CodeMnemonics.JumpIfFalse)
                {
                    long testvalue = GetAndExtendAsNecessary(_currentinstruction + 1);
                    if (opcode.Modes[0] == ParameterMode.Position)
                        testvalue = GetAndExtendAsNecessary(testvalue);
                    if (opcode.Modes[0] == ParameterMode.Relative)
                        testvalue = GetAndExtendAsNecessary( testvalue +_relativeBaseOffset);

                    long location = GetAndExtendAsNecessary(_currentinstruction + 2);
                    if (opcode.Modes[1] == ParameterMode.Position)
                        location = GetAndExtendAsNecessary(location);
                    if (opcode.Modes[1] == ParameterMode.Relative)
                        location = GetAndExtendAsNecessary(location+_relativeBaseOffset);

                    if ((opcode.Code == CodeMnemonics.JumpIfTrue && testvalue > 0) || (opcode.Code == CodeMnemonics.JumpIfFalse && testvalue == 0)) 
                    {
                        _currentinstruction = location;
                        opcode.SetJumpToZero();
                    }
                }
                if(opcode.Code == CodeMnemonics.RelativeBaseOffset)
                {
                    long location = _currentinstruction + 1;
                    if (opcode.Modes[0] == ParameterMode.Position)
                        location = GetAndExtendAsNecessary(location);
                    if (opcode.Modes[0] == ParameterMode.Relative)
                        location = GetAndExtendAsNecessary(location) + _relativeBaseOffset;

                    _relativeBaseOffset += GetAndExtendAsNecessary(location);
                }
                _currentinstruction += opcode.Jump;
            }
            _state = CompilerState.Halted;
            return GetAndExtendAsNecessary(0);
        }

        long GetAndExtendAsNecessary(long i)
        {
            if(!_sourceCode.ContainsKey(i))
                _sourceCode.Add(i, 0);
            return _sourceCode[i];
        }
        void SetAndExtendAsNecessary(long i, long value)
        {
            if (_sourceCode.ContainsKey(i))
                _sourceCode[i] = value;
            else
                _sourceCode.Add(i, value);
        }

        void Output(long i)
        {
            _lastOutput = i;
            if(_useConsoleInput)
                Console.WriteLine("[{0}]: {1}", _currentinstruction, i);
            _outputQueue.Enqueue(i);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} [0]: {4}", _name, _currentinstruction, _state, _lastOutput, _sourceCode[0]);
        }
    }
}
