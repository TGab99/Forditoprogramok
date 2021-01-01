using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Forditoprogramok
{
    public class SourceHandler
    {
        string source, finalCode = "";
        string content = "";

        Dictionary<string, string> replaces = new Dictionary<string, string>();

        List<string> symbolTable = new List<string>();
        int symbolTableIndex = 0;

        public SourceHandler(string source, string finalCode)
        {
            this.source = source;
            this.finalCode = finalCode;
        }

        public void addToDictionary(string path)
        {
            StreamReader SR = new StreamReader(File.OpenRead(path));
            while(SR.Peek() > -1)
            {
                string s = SR.ReadLine();
                string[] queue = s.Split(",");
                replaces.Add(queue[0], queue[1]);
            }
            SR.Close();
        }

        public string changeVariablesAndContans(string varAndConstName)
        {
            symbolTable.Add(varAndConstName);
            symbolTableIndex += 1;
            string res = "00" + symbolTableIndex.ToString();

            return res.Substring(res.Length-3);
        }

        public void replaceContent()
        {
            var blockComment = @"/[*][\w\d\s]+[*]/";
            var lineComments = @"//.*?\n";

            string patternNum = @"([0-9]+)";
            string patternVar = @"([a-z-_]+)";

            content = Regex.Replace(content, blockComment, " ");
            content = Regex.Replace(content, lineComments, " ");

            content = Regex.Replace(content, patternNum, changeVariablesAndContans("$1"));
            content = Regex.Replace(content, patternVar, changeVariablesAndContans("$1"));

            foreach (var x in replaces)
            {
                while (content.Contains(x.Key))
                {
                    content = content.Replace(x.Key, x.Value);
                }
            }
        }

        public void openFileToRead()
        {
            try
            {
                StreamReader SR = new StreamReader(File.OpenRead(source));
                content = SR.ReadToEnd();
                SR.Close();

            }catch(IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void openFileToWrite()
        {
            try
            {
                StreamWriter SW = new StreamWriter(File.Open(finalCode,FileMode.Create));
                SW.WriteLine(content);
                SW.Flush();
                SW.Close();

            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
