using LibraryApplication.Models;
using LibraryApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Repositories
{
    public class BookRepository
    {
        public List<Book> BooksList;
        private readonly FileService _fileService;
        private readonly BookReturnControlService _returnBookControlService;

        public BookRepository()
        {
            _fileService = new FileService();
            _returnBookControlService = new BookReturnControlService();
            BooksList = _fileService.ParseFromJsonFile().ToList();
        }

        public List<Book> GetAll()
        {
            return BooksList;
        }

        public void Post(Book book)
        {
            BooksList.Add(book);
        }

        public void DeleteById(int id)
        {
            var book = BooksList.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                BooksList.Remove(book);
            }
        }

        public void UpdateBorrowById(int id, Customer customer)
        {
            var book = BooksList.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                if (!book.IsTaken)
                {
                    book.IsTaken = true;
                    book.Customer = customer;
                }
            }
        }

        public void RerurnById(int id)
        {
            var book = BooksList.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                if (book.IsTaken)
                {
                    book.IsTaken = false;
                    book.Customer = null;
                }
            }
        }

        public void SaveChanges()
        {
            _fileService.ParseToJsonFile(BooksList);
        }
    }
}
