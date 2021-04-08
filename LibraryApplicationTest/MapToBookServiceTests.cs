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
    public class MapToBookServiceTests
    {
        [Fact]
        public void MapUserInput_GivenDictionaryWithStringValues_MapToBookObject()
        {
            var userInput = new Dictionary<string, string>()
            {
                {"Name", "Romeo and Juliet" },
                {"Author Name", "William" },
                {"Author Surname", "Shakspeare" },
                {"Publication Date", "1823" },
                {"Category", "Tragedy"},
                {"Language", "English" },
                {"ISBN", "325671" }
            };
            var map = new ConverterService();

            var result = map.ConvertToBook(userInput);

            result.Should().NotBeNull();
            result.Name.Should().Be("Romeo and Juliet");
            result.PublicationDate.Should().BeLessThan(2021);
            result.Language.Should().Be(Languages.English);
            result.Category.Should().Be(Categories.Tragedy);
        }
    }
}
