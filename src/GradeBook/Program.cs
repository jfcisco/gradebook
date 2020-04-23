using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Scott's Grade Book");
            
            
            while (true)
            {
                Console.Write("Enter a grade or 'q' to quit: ");
                var userInput = Console.ReadLine();

                if (userInput.ToUpper() == "Q")
                {
                    break;
                }

                

                try 
                {
                    var gradeToBeAdded = double.Parse(userInput);
                    book.AddGrade(gradeToBeAdded);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            
            /* book.AddGrade(89.1);
            book.AddGrade(96.4);
            book.AddGrade(100.0);
            book.AddGrade(88.3);  */

            book.ShowStatistics();
        }
    }
}
