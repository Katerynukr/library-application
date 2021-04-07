using LibraryApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class BookService
    {
        private readonly DataService _dataService;
        private readonly MapToBookService _mapToBookService;
        public BookService(DataService dataService, MapToBookService mapToBookService)
        {
            _dataService = dataService;
            _mapToBookService = mapToBookService;
        }

        public IEnumerable<Book> ListAllBooks()
        {
            return _dataService.ParseFromJsonFile();
        }

        public void AddBook(Dictionary<string, string> userInput)
        {
            _dataService.ParseFromJsonFile();
            var book = _mapToBookService.MapUserInput(userInput);
            IEnumerable<Book> newList = _dataService.books.Append(book);
            _dataService.ParseToJsonFile(newList);
            //TODO: input validation
        }

        public void DeleteBook(int id)
        {
            _dataService.ParseFromJsonFile();
            var booksList = _dataService.books.ToList();
            var book = booksList.FirstOrDefault(b => b.Id == id);
            if(book != null)
            {
                booksList.Remove(book);
                _dataService.ParseToJsonFile(booksList);
            }
        }

        public void TakeBook(int id, Customer customer)
        {
            //TODO: AMOUNT  DATE
            _dataService.ParseFromJsonFile();
            var booksList = _dataService.books.ToList();
            var book = booksList.FirstOrDefault(b => b.Id == id);
            if(!book.IsTaken)
            {
                book.IsTaken = true;
                book.Customer = customer;
                IEnumerable<Book> newList = _dataService.books.Append(book);
                _dataService.ParseToJsonFile(newList);
            }
        }

        public void ReturnBook(int id)
        {
            //TODO:Message
            _dataService.ParseFromJsonFile();
            var booksList = _dataService.books.ToList();
            var book = booksList.FirstOrDefault(b => b.Id == id);
            if (book.IsTaken)
            {
                book.IsTaken = false;
                book.Customer = null;
                IEnumerable<Book> newList = _dataService.books.Append(book);
                _dataService.ParseToJsonFile(newList);
            } 
        }
    }
}
