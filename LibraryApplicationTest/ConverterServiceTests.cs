using FluentAssertions;
using LibraryApplication.Models;
using LibraryApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApplicationTest
{
    public class ConverterServiceTests
    {
        [Fact]
        public void ConvertToCustomer_GivenDictionaryWithNameSurnameDate_CreateAuthor()
        {
            Dictionary<string, string> name = new()
            {
                { "Customer Name", "Test" },
                { "Customer Surname", "Tester" },
            };
            var date = DateTime.Now;
            ConverterService converterService = new();

            var result = converterService.ConvertToCustomer(name, date);

            result.Should().NotBeNull();
        }

        [Fact]
        public void ConvertToBook_GivenDictionaryWithStringValues_CreateAuthor()
        {
            Dictionary<string, string> dataString = new()
            {
                { "Name", "Test" },
                { "Surname", "Tester" },
                { "Book Title" , "Test"},
                { "ISBN", "1246" },
                { "Language", "english" },
                { "Category", "drama" },
                { "Publication Year", "2020"},
                { "Author Name", "Test"},
                { "Author Surname", "Tester"}
            };
            var date = DateTime.Now;
            ConverterService converterService = new();

            var result = converterService.ConvertToBook(dataString);

            result.Should().NotBeNull();
            result.Name.Should().Be("Test");
        }
    }
}
