using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }
    public class Book : NamedObject
    {
        public Book(string name) : base(name)
        {
            grades = new List<double>();        }

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);                
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }            
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
            result.Letter = GetLetterGrade(result.Average);

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

        public char GetLetterGrade(double grade)
        {
            switch (grade)
            {
                case var g when g >= 90:
                    return 'A';
                
                case var g when g >= 80:
                    return 'B';

                case var g when g >= 70:
                    return 'C';
                
                case var g when g >= 60:
                    return 'D';
                
                default:
                    return 'F';
            }
        }

        public void ShowStatistics()
        {
            var result = GetStatistics();
            Console.WriteLine($"The average grade is {result.Average:N2}");
            Console.WriteLine($"The lowest grade is {result.Low}");
            Console.WriteLine($"The highest grade is {result.High}");
            Console.WriteLine($"The letter grade is {result.Letter}");
        } 

        List<double> grades;
    }
}