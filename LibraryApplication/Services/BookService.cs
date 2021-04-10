using LibraryApplication.Models;
using LibraryApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;
        private readonly ConverterService _converterService;
        private readonly BookInputValidationService _bookInputValidationService;

        public BookService()
        {
            _bookRepository = new BookRepository(); 
            _converterService = new ConverterService();
            _bookInputValidationService = new BookInputValidationService();
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().Where(b => b.IsTaken == false).ToList();
        }

        public void AddNewBook(Dictionary<string, string> userInput)
        {
            var userInputValidationResult = _bookInputValidationService.IsValidDataForNewBook(userInput);
            if (userInputValidationResult == true)
            {
                var book = _converterService.ConvertToBook(userInput);
                _bookRepository.Post(book);
            }
        }

        public void DeleteBook(string idString)
        {
            var isValidStringId = _bookInputValidationService.IsValidStringId(idString);
            if (isValidStringId)
            {
                int id = _converterService.ConvertToInteger(idString);
                _bookRepository.DeleteById(id);
            }
        }

        public void BorrowBook(string[] bookIdsString, Dictionary<string, string> customerDataInput)
        {
            var userInputValidationResult = _bookInputValidationService.IsValidDataToBorrowBook(customerDataInput, bookIdsString);
            if (userInputValidationResult == true)
            {
                var borrowDate = DateTime.Now;
                var customer = _converterService.ConvertToCustomer(customerDataInput, borrowDate);
                var ids = _converterService.ConvertToIntegerArray(bookIdsString);
                var countOfIds = 0;
                foreach (var id in ids)
                {
                    if(countOfIds < 3)
                    {
                        _bookRepository.UpdateBorrowById(id, customer);
                        countOfIds++;
                        break;
                    }
                }
            }
        }

        public void ReturnBook(string idString)
        {
            var isValidStringId = _bookInputValidationService.IsValidStringId(idString);
            if (isValidStringId)
            {
                int id = _converterService.ConvertToInteger(idString);
                _bookRepository.RerurnById(id);
            }
        }

        public void SaveChanges()
        {
            _bookRepository.SaveChanges();
        }
    }
}
