using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BooksTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
            Assert.Equal('B', result.Letter);
        }

        [Fact]
        public void OnlyValidGradesCanBeAdded()
        {
            var book = new Book("");
            book.AddGrade(85.00);
            Action beyondRangeGrade = () => book.AddGrade(101.00);
            Action belowRangeGrade = () => book.AddGrade(-1.00);

            Assert.Throws<ArgumentException>(beyondRangeGrade);
            Assert.Throws<ArgumentException>(belowRangeGrade);
        }
    }
}
