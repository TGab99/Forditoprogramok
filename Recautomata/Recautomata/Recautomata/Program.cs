using System;

namespace Recautomata
{
    class Program
    {
        static void Main(string[] args)
        {
            Automata automata = new Automata("(31+22)*55");
            automata.S();
        }
    }
}
