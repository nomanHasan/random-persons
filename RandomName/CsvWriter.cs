using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace RandomPersons
{
    class CsvWriter
    {
        static string[] columns = { "FirstName", "LastName", "UserName", "SSC_Grade",
                "HSC_Grade", "Bachelor_Grade", "Age", "Gender", "Email", "DateOfBirth", "Street",
                "Suite", "City", "ZipCode"
            };

        private string fileName;
        private int rowCount;
        static string columnRow;

        public CsvWriter(string fileName, int rowCount)
        {
            this.fileName = fileName;
            this.rowCount = rowCount;
            columnRow = string.Join(", ", columns);
        }

        public void WriteFile()
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(this.fileName))
            {
                file.WriteLine(columnRow);

                for (int i = 0; i < rowCount; i++)
                {
                    var line = PersonGenerator.GetPersonLine();
                    //Console.WriteLine($"{fileName}: {i}");
                    file.WriteLine(line);
                }
            }
        }

        public void WriteFileDemo()
        {
            Console.WriteLine($"{this.fileName}, {this.rowCount} ... Generating");
            Thread.Sleep(2000);
            Console.WriteLine($"{this.fileName} Generated " + PersonGenerator.GetPersonLine());
            Thread.Sleep(200);
        }

        public static List<CsvWriter> GetCSVWriters(string fileName = "RandomPersons", int rowCount = 10000, int concurrency = 5, string extension = "csv")
        {
            List<CsvWriter> cwList = new List<CsvWriter>();

            int rowPerCw = rowCount / concurrency;

            Enumerable.Range(1, concurrency).ToList().ForEach(el =>
            {
                cwList.Add(new CsvWriter($"{fileName}{el}.{extension}", rowPerCw));
            });

            return cwList;
        }


        public static void ExecuteParrallelWrite(string fileName = "RandomPersons", int rowCount = 100000, int concurrency = 5, string extension = "csv")
        {
            List<CsvWriter> writers = CsvWriter.GetCSVWriters(fileName, rowCount, concurrency, extension);

            List<Thread> threads = writers.Select(w => new Thread(w.WriteFile)).ToList();

            Stopwatch sw = new Stopwatch();

            sw.Start();

            threads.ForEach(t => t.Start());

            Console.WriteLine("CSV Generation has Started");

            threads.ForEach(t => t.Join());

            sw.Stop();

            Console.WriteLine("Threads have Finished in " + sw.Elapsed);

        }

    }
}
