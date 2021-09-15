using System;
using System.IO;
using System.Collections.Generic;
using System.Data;

namespace CSVReader
{


    class Program
    {
        




        static void Main(string[] args)
        {

            if (args.Length != 1)
            {
                Console.WriteLine("Invalid number of Arguments");
                return;
            }
            string filename = args[0];
            if (File.Exists(args[0]))
            {
                var parser = new CSVParse(filename);
                parser.ParseCSV();
                parser.WriteOut();
            }
            else
            {
                Console.WriteLine("No such file or directory");

            }
        }
    }
}
