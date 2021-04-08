using FluentAssertions;
using LibraryApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApplicationTest
{
    public class BookInputValidationTests
    {
        [Fact]
        public void IsValidCategory_GivenInputString_CheckIsStringHasEnumValue()
        {
            var userInput = new Dictionary<string, string>()
            {
                { "Category", "Drama" }
            };
            var bookValidation = new BookInputValidation();

            var result = bookValidation.IsValidCategory(userInput);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidISVN_GivenInputString_CheckIsStringHasDigitsOnly()
        {
            var userInput = new Dictionary<string, string>()
            {
                { "ISBN", "543892" }
            };
            var bookValidation = new BookInputValidation();

            var result = bookValidation.IsValidISBN(userInput);

            result.Should().BeTrue();
        }

        [Fact]
        public void IsValidPublicationDate__GivenInputString_CheckIsYearValid()
        {
            var userInput = new Dictionary<string, string>()
            {
                { "Publication Date", "2040" }
            };
            var bookValidation = new BookInputValidation();

            var result = bookValidation.IsValidPublicationYear(userInput);

            result.Should().BeFalse();
        }

        [Fact]
        public void IsValidAuthorName__GivenInputString_CheckDoesStringContainLettersOnly()
        {
            var userInput = new Dictionary<string, string>()
            {
                { "Author Name", "William" },
                { "Author Surname", "Shakspeare"  }
            };
            var bookValidation = new BookInputValidation();

            var result = bookValidation.IsValidAuthorName(userInput);

            result.Should().BeTrue();
        }
    }
}
