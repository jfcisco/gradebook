using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(96.4);
            book.AddGrade(100.0);
            book.AddGrade(88.3);

            book.ShowStatistics();

            /* List<double> grades = new List<double>()  { 12.7, 10.3, 6.11, 4.1 };
            grades.Add(56.1);
                             
            var results = 0.0;
            foreach(double grade in grades)
            {
                results += grade;
            }

            results /= grades.Count;
            Console.WriteLine($"The average grade is {results:N1}"); */
        }
    }
}
