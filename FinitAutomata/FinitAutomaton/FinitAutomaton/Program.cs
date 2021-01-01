using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinitAutomaton
{
    class Program
    {
        static void Main(string[] args)
        {
            Automaton A = new Automaton();

            string content;
            List<string> list = new List<string>();

            try
            {
                StreamReader SR = new StreamReader(
                    File.OpenRead(@"/Users/torokgabriella/Projects/FinitAutomaton/FinitAutomaton/text/input.txt"));
                while (!SR.EndOfStream)
                {
                    content = SR.ReadLine();
                    string[] spieces = content.Split(' ');
                    for(int i = 0; i < spieces.Length; i++)
                    {
                        list.Add(spieces[i]);
                    }

                }
                SR.Close();

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            A.prepare();

            for(int i = 0; i < list.Count; i++)
            {
                A.main(list[i]);
            }
        }
    }
}
