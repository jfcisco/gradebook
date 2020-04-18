using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.Name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        double ComputeAverage()
        {
            double sumOfGrades = 0.0;

            foreach (double grade in grades)
            {
                sumOfGrades += grade;
            }

            return sumOfGrades / grades.Count;
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = ComputeAverage();
            result.High = GetHighestGrade();
            result.Low = GetLowestGrade();

            return result;
        }

        double GetLowestGrade()
        {
            double lowestGrade = double.MaxValue;

            foreach (double grade in grades)
            {
                lowestGrade = Math.Min(grade, lowestGrade);
            }

            return lowestGrade;
        }

        double GetHighestGrade()
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
        public string Name;
    }
}