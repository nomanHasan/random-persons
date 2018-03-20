using System;
using RandomNameGeneratorLibrary;
using Bogus;

namespace RandomName
{
    class Program
    {

        static Random rand = new Random();
        static string[] divisions = { "1st Division", "2nd Division", "3rd Division" };

        static void Main(string[] args)
        {

            string[] columns = { "FirstName", "LastName", "UserName", "SSC_Grade",
                "HSC_Grade", "Bachelor_Grade", "Age", "Gender", "Email", "DateOfBirth", "Street",
                "Suite", "City", "ZipCode"
            };
            
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"RandomPersons.csv"))
            {
                var columnRow = string.Join(", ", columns);
                file.WriteLine(columnRow);

                for (int i = 0; i < 1000000; i++)
                {
                    int sr = rand.Next(0, 3);
                    int hr = rand.Next(0, 3);
                    var person = new Bogus.Person();
                    var line = $"{person.FirstName}," +
                        $" {person.LastName}, {person.UserName}, " +
                        $"{GetGrade(6)}, {GetGrade(6)}, {GetGrade(5)}, " +
                        $"{ new DateTime(DateTime.Now.Subtract(person.DateOfBirth).Ticks).Year - 1}, " +
                        $"{person.Gender}, " +
                        $"{person.Email}, {person.DateOfBirth}, {person.Address.Street}, " +
                        $"{person.Address.Suite}, {person.Address.City}, {person.Address.ZipCode}";

                    Console.WriteLine(i);
                    file.WriteLine(line);
                }
            }

            Console.WriteLine("Write Finished");

        }

        static string GetGrade(int gradeMax)
        {
            int type = rand.Next(1, 10);

            int grade = rand.Next(1, gradeMax);
            

            if(type > 3)
            {
                return $"GPA {grade}.00";
            } else
            {
                int div = rand.Next(0, 2);
                return $"{divisions[div]}";
            }
        }
    }
}
