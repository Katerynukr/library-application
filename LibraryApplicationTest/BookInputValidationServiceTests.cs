using FluentAssertions;
using LibraryApplication.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

using Xunit;

namespace LibraryApplicationTest
{
    public class BookInputValidationServiceTests
    {
        [Xunit.Theory]
        [InlineData("1", true)]
        [InlineData("11", true)]
        public void IsValidStringId_GivenIdStringt(string idString, bool resultBool)
        {
            var validation = new BookInputValidationService();
            var result = validation.IsValidStringId(idString);
            result.Should().Be(resultBool);
        }

        [Fact]
        public void IsValidLanguage()
        {
            var dataString = new Dictionary<string, string>()
            {
                {"Language", "Test"}
            };
            var validation = new BookInputValidationService();
            Xunit.Assert.Throws<Exception>(() => validation.IsValidLanguage(dataString));
        }
    }
}
