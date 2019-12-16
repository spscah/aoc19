using System.Collections.Generic;

namespace DayFive
{
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
}
