using System;
using System.Collections.Generic;

namespace FinitAutomaton
{
    public class Automaton
    {
        string state = "A";
        Dictionary<String, String> D = new Dictionary<string, string>();

        public void prepare()
        {
            D.Add("A+", "B");
            D.Add("A-", "B");
            D.Add("Ad", "C");
            D.Add("Bd", "C");
            D.Add("Cd", "C");
        }

        public char convert(char c)
        {
            if (Char.IsDigit(c))
            {
                return 'd';
            }

            return c;
        }

        public string delta(string st, char act)
        {
            if (D.ContainsKey(st + convert(act)))
            {
                return D[st + convert(act)];
            }

            return "Error";
        }

        public void main(string input)
        {
            int i = 0;
            while(i < input.Length && state != "Error")
            {
                state = delta(state, input[i]);
                i++;
            }

            if(state != "Error")
            {
                Console.WriteLine("{0} helyes bemenő adat", input);
            }
            else
            {
                Console.WriteLine(
                    "{0} nem helyes bemenő adat. Hibás karakter található {1}. helyen!", input, i);
            }
        }
    }
}
