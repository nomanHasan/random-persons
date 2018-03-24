using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace RandomPersons
{
    class PersonGenerator
    {

        static Random rand = new Random();

        public static string GetPersonLine()
        {
            var person = new Bogus.Person();
            var line = $"{person.FirstName}, " +
                $"{person.LastName}, {person.UserName}, " +
                $"{GetGrade(6)}, {GetGrade(6)}, {GetGrade(5)}, " +
                $"{ new DateTime(DateTime.Now.Subtract(person.DateOfBirth).Ticks).Year - 1}, " +
                $"{person.Gender}, " +
                $"{person.Email}, {person.DateOfBirth}, {person.Address.Street}, " +
                $"{person.Address.Suite}, {person.Address.City}, {person.Address.ZipCode}";

            return line;
        }
        static string[] divisions = { "1st Division", "2nd Division", "3rd Division" };

        static string GetGrade(int gradeMax)
        {
            int type = rand.Next(1, 10);

            int grade = rand.Next(1, gradeMax);


            if (type > 3)
            {
                return $"GPA {grade}.00";
            }
            else
            {
                int div = rand.Next(0, 2);
                return $"{divisions[div]}";
            }
        }


    }

}
