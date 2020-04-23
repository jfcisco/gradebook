using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogMessage(string message);
    public class TypeTests
    {
        [Fact]
        public void CanInvokeMethodsFromDelegate()
        {
            WriteLogMessage log;
            log = WriteMessage;

            var result = log("Delegate called");
            Assert.Equal("Message written! Delegate called", result);
        }

        private string WriteMessage(string message)
        {
            return $"Message written! {message}";
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);
            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void PassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string newName)
        {
            book.Name = newName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
        }
        
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            
            Assert.Same(book1, book2);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string string1 = "Hello";
            var upper = MakeUppercase(string1);

            Assert.Equal("Hello", string1);
            Assert.Equal("HELLO", upper);
        }

        private string MakeUppercase(string word)
        {
            return word.ToUpper();
        }
    }
}
