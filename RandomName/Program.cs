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


            Console.Write("File Name: ");

            string fileName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Row Count: ");

            int rowCount= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Concurrency : ");

            int concurrency = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Extension: ");

            string extension = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Configuration: " + fileName + " " + rowCount + " " + concurrency + " " + extension);


            CsvWriter.ExecuteParrallelWrite(fileName, rowCount, concurrency, extension);


            Console.ReadLine();

        }
    }
}
