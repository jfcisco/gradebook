using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public double ComputeAverage()
        {
            double sumOfGrades = 0.0;

            foreach (double grade in grades)
            {
                sumOfGrades += grade;
            }

            return sumOfGrades / grades.Count;
        }

        public double GetLowestGrade()
        {
            double lowestGrade = double.MaxValue;

            foreach (double grade in grades)
            {
                lowestGrade = Math.Min(grade, lowestGrade);
            }

            return lowestGrade;
        }

        public double GetHighestGrade()
        {
            double highestGrade = double.MinValue;

            foreach (double grade in grades)
            {
                highestGrade = Math.Max(grade, highestGrade);
            }

            return highestGrade;
        }

        public void ShowStatistics()
        {
            Console.WriteLine($"The average grade is {ComputeAverage()}");
            Console.WriteLine($"The lowest grade is {GetLowestGrade()}");
            Console.WriteLine($"The highest grade is {GetHighestGrade()}");
        } 

        List<double> grades;
        string name;
    }
}