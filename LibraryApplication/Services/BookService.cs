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
        private readonly BookRepositoryService _bookRepositoryService;
        private readonly ConverterService _converterService;
        private readonly BookInputValidation _bookInputValidation;
        public BookService()
        {
            _bookRepositoryService = new BookRepositoryService(); 
            _converterService = new ConverterService();
            _bookInputValidation = new BookInputValidation();
        }

        public List<Book> ListAllBooks()
        {
            return _bookRepositoryService.GetAll();
        }

        public void AddNewBook(Dictionary<string, string> userInput)
        {
            var userInputValidationResult = _bookInputValidation.IsValidDataForNewBook(userInput);
            if (userInputValidationResult == true)
            {
                var book = _converterService.ConvertToBook(userInput);
                _bookRepositoryService.Post(book);
            }
        }

        public void DeleteBook(string idString)
        {
            var isValidStringId = _bookInputValidation.IsValidStringId(idString);
            if (isValidStringId)
            {
                int id = _converterService.ConvertToInteger(idString);
                _bookRepositoryService.DeleteById(id);
            }
        }

        public void BorrowBook(string[] bookIdsString, Dictionary<string, string> customerDataInput, string estimatedReturnDateString)
        {

            var userInputValidationResult = _bookInputValidation.IsValidDataToBorrowBook(customerDataInput, estimatedReturnDateString, bookIdsString);
            if (userInputValidationResult == true)
            {
                //how many ids not nore than 3
                var customer = _converterService.ConvertToCustomer(customerDataInput, estimatedReturnDateString);
                var ids = _converterService.ConvertToIntegerArray(bookIdsString);
                foreach (var id in ids)
                {
                    _bookRepositoryService.UpdateBorrowById(id, customer);
                }
            }
        }

        public void ReturnBook(string idString)
        {
            var isValidStringId = _bookInputValidation.IsValidStringId(idString);
            if (isValidStringId)
            {
                int id = _converterService.ConvertToInteger(idString);
                //TODO:Message
                _bookRepositoryService.RerurnById(id);
            }
        }
    }
}
