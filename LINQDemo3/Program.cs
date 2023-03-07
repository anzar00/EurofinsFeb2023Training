using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //   List<string> woeds = new List<string>();

            XDocument xml = XDocument.Load("XMLFile1.xml");

            var short_words = from w in xml.Descendants("word;") 
                              where w.Value.Length <=3
                              select w.Value;
            foreach (var word in short_words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
