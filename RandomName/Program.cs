using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace RandomPersons
{
    class Program
    {

        static void Main(string[] args)
        {


            List<CsvWriter> writers = CsvWriter.GetCSVWriters("PeopleOfDhaka", 1000000, 4, "csv");

            List<Thread> threads = writers.Select(w => new Thread(w.WriteFile)).ToList();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            threads.ForEach(t => t.Start());

            Console.WriteLine("Thread has Started");

            threads.ForEach(t => t.Join());

            sw.Stop();

            Console.WriteLine("Threads has Finished" + sw.Elapsed);

            
            Console.WriteLine("Write Finished");



            Console.ReadLine();

        }
    }
}
