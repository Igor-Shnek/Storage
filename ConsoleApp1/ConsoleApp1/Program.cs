using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Text a = new Text(@"H:\input.txt", @"H:\output.txt");
            a.writeTheFile(a.transformText(a.readTheFile()));
        }
    }
}
