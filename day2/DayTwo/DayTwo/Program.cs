using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int> { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 19, 1, 19, 10, 23, 2, 13, 23, 27, 1, 5, 27, 31, 2, 6, 31, 35, 1, 6, 35, 39, 2, 39, 9, 43, 1, 5, 43, 47, 1, 13, 47, 51, 1, 10, 51, 55, 2, 55, 10, 59, 2, 10, 59, 63, 1, 9, 63, 67, 2, 67, 13, 71, 1, 71, 6, 75, 2, 6, 75, 79, 1, 5, 79, 83, 2, 83, 9, 87, 1, 6, 87, 91, 2, 91, 6, 95, 1, 95, 6, 99, 2, 99, 13, 103, 1, 6, 103, 107, 1, 2, 107, 111, 1, 111, 9, 0, 99, 2, 14, 0, 0 };
            input[1] = 12;
            input[2] = 2;
            Console.WriteLine("Q1: {0}", Calculate(input));
            int noun = 0;
            int verb = 0;
            int limit = 100;
            int lowest = -1;
            // 6735 was the first with the noun leading. 
            for(noun = 0; noun <= limit; ++noun) 
            { 
                for (verb = 0; verb <= limit; ++verb)
                {
                    input = new List<int> { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 19, 1, 19, 10, 23, 2, 13, 23, 27, 1, 5, 27, 31, 2, 6, 31, 35, 1, 6, 35, 39, 2, 39, 9, 43, 1, 5, 43, 47, 1, 13, 47, 51, 1, 10, 51, 55, 2, 55, 10, 59, 2, 10, 59, 63, 1, 9, 63, 67, 2, 67, 13, 71, 1, 71, 6, 75, 2, 6, 75, 79, 1, 5, 79, 83, 2, 83, 9, 87, 1, 6, 87, 91, 2, 91, 6, 95, 1, 95, 6, 99, 2, 99, 13, 103, 1, 6, 103, 107, 1, 2, 107, 111, 1, 111, 9, 0, 99, 2, 14, 0, 0 };
                    input[1] = noun;
                    input[2] = verb;
                    if(Calculate(input) == 19690720)
                    {
                        Console.WriteLine("Solution: {0},{1}", noun, verb);
                        if (lowest < 0 || lowest < (100 * noun + verb))
                            lowest = (100 * noun + verb);
                    }
                }
            }
            Console.Write("Q2: {0}", lowest);
            Console.ReadKey();
        }

        public static int Calculate(List<int> memory)
        {
            int index = 0;
            while(memory[index] != 99)
            {
                int opcode = memory[index];
                int a = memory[memory[index + 1]];
                int b = memory[memory[index + 2]];
                int location = memory[index + 3];
                if (location >= memory.Count)
                    throw new UnexpectedLocationException(location);
                if (opcode == 99)
                    return memory[0];
                if (opcode != 1 && opcode != 2)
                    throw new UnexpectedOpcodeException(opcode);
                if (location >= memory.Count)
                    memory.AddRange(Enumerable.Repeat(0, location+1 -memory.Count));
                if(opcode == 1)
                    memory[location] = a + b;
                if (opcode == 2)
                    memory[location] = a * b;
                index += 4;
                if (index >= memory.Count)
                    throw new UnexpectedLocationException(index);
            }
            return memory[0];
        }
    }

    internal class UnexpectedOpcodeException : Exception
    {
        private int opcode;

        public UnexpectedOpcodeException()
        {
        }

        public UnexpectedOpcodeException(int opcode) : base(string.Format("Opcode: {0} is not expected", opcode))
        {
            this.opcode = opcode;
        }

    }
    internal class UnexpectedLocationException : Exception
    {
        private int opcode;

        public UnexpectedLocationException()
        {
        }

        public UnexpectedLocationException(int opcode) : base(string.Format("Location: {0} is out of range", opcode))
        {
            this.opcode = opcode;
        }

    }
}
