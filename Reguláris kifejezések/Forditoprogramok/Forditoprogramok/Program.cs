using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Collections.Generic;

namespace Forditoprogramok
{
    class Program
    {
        static void Main(string[] args)
        {
            SourceHandler sh = new SourceHandler(@"/Users/torokgabriella/Projects/Forditoprogramok/Forditoprogramok/Files/text.txt",
                "/Users/torokgabriella/Projects/Forditoprogramok/Forditoprogramok/Files/text2.txt");

            sh.addToDictionary(@"/Users/torokgabriella/Projects/Forditoprogramok/Forditoprogramok/Files/replaces.txt");
            sh.openFileToRead();
            sh.replaceContent();
            sh.openFileToWrite();
        }
    }
}
