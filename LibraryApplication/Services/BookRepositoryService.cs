using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class BookRepositoryService
    {
        private readonly DataService _dataService;

        public BookRepositoryService()
        {
            _dataService = new DataService();
        }

        public List<Book> GetAll()
        {
            return _dataService.ParseFromJsonFile().ToList();
        }

        public void Post(Book book)
        {
            var booksList = GetAll();
            booksList.Add(book);
            _dataService.ParseToJsonFile(booksList);
        }

        public void DeleteById(int id)
        {
            var booksList = GetAll();
            var book = booksList.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                booksList.Remove(book);
                _dataService.ParseToJsonFile(booksList);
            }
        }

        public void UpdateBorrowById(int id, Customer customer)
        {
            var booksList = GetAll();
            var book = booksList.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                if (!book.IsTaken)
                {
                    book.IsTaken = true;
                    book.Customer = customer;
                    //booksList .Add(book);
                    _dataService.ParseToJsonFile(booksList);
                }
            }
        }

        public void RerurnById(int id)
        {
            var booksList = GetAll();
            var book = booksList.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                if (book.IsTaken)
                {
                    //service for comparing a dates
                    //book.Customer.BorrowDate;
                    book.IsTaken = false;
                    book.Customer = null;
                    //booksList.Add(book);
                    _dataService.ParseToJsonFile(booksList);
                }
            }
        }
    }
}
