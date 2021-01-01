﻿using System;
using System.Text.RegularExpressions;

namespace Recautomata
{
    public class Automata
    {
        string input;
        int i = 0;

        public string simple(string st)
        {
            return Regex.Replace(st, "([0-9]+)", "i");
        }

        public Automata(string input)
        {
            Console.WriteLine("Az eredeti input: {0}", input);
            this.input = $"{simple(input)}#";
            Console.WriteLine("Az egyszerűsített input: {0}", this.input);
        }

        public void elfogad(char ch)
        {
            if (input[i] != ch)
            {
                Console.WriteLine("Hibás input : {0}. Helytelen karakter: {1}", input, input[i]);
            }
            i++;
        }

        public void S()
        {
            E();
            elfogad('#');
            Console.WriteLine("Az elemzés lefutott!");
        }

        void E()
        {
            T();
            Ev();
        }

        void T()
        {
            F();
            Tv();
        }

        void Ev()
        {
            if(input[i] == '+')
            {
                elfogad('+');
                T();
                Ev();
            }
        }

        void Tv()
        {
            if(input[i] == '*')
            {
                elfogad('*');
                F();
                Tv();
            }
        }

        void F()
        {
            if(input[i] == '(')
            {
                elfogad('(');
                E();
                elfogad(')');
            }
            else
            {
                elfogad('i');
            }
        }
    }
}
