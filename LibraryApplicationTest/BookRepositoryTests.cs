using FluentAssertions;
using LibraryApplication.Models;
using LibraryApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LibraryApplicationTest
{
    public class BookRepositoryTests
    {
        [Fact]
        public void GetAll_GivenBookList_ShouldReturnList()
        {
            List<Book> testData = new() {
                new Book()
                {
                    Name = "Test",
                    Author = new()
                    {
                        Name = "Test",
                        Surname = "Test"
                    },
                    ISBN = "1234",
                    Category = Categories.adventure,
                    Language = Languages.english,
                    PublicationDate = DateTime.Now.Year

                }
            };
            var bookRepository = new BookRepository();

            var result = bookRepository.GetAll();

            result.Should().NotBeEmpty();
        }
    }
}
