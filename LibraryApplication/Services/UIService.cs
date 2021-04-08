using LibraryApplication.Interfaces;
using LibraryApplication.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class UIService
    {
        private readonly DisplayMessageService _displayMessageService;
        private readonly BookService _bookService;
        private readonly InstructionService _instructionService;

        public UIService(ILogger logger)
        {
            _displayMessageService = new DisplayMessageService(logger);
            _bookService = new BookService();
            _instructionService = new InstructionService();
        }

        public string DisplayListOfCommands()
        {
            string availableCommands = _instructionService.ReturnAvailableCommands();
            _displayMessageService.WriteResult(availableCommands);
            var command = _displayMessageService.ReadCommand().Trim().ToLower();
            return command;
        }

        public void GenerateListOfBooks()
        {
            var books = _bookService.ListAllBooks();
            var availableBooks = books.Where(b => b.IsTaken == false).ToList();
            availableBooks.ForEach(b => _displayMessageService.WriteResult($"Id: {b.Id} Title: {b.Name} \n " +
                $"Author: {b.Author.Name} {b.Author.Surname}"));
        }

        public void AddNewBook()
        {
            var instructionForUser = _instructionService.RerturnInstructionsToAddNewBook();
            var dataFieldsToCreateBook = _instructionService.ReturnDataFieldsToCreateBook();
            Dictionary<string, string> userInputForNewBook = new Dictionary<string, string>();
            _displayMessageService.WriteResult(instructionForUser);
            foreach (var bookField in dataFieldsToCreateBook)
            {
                _displayMessageService.WriteResult(bookField);
                var input = _displayMessageService.ReadCommand().Trim().ToLower();
                userInputForNewBook.Add(bookField, input);
            }
            _bookService.AddNewBook(userInputForNewBook);
            //TODO:MESSAGES FOR SUCCESS
            //TODO:MESSAGES FOR error

        }
        public void DeleteBook()
        {
            string instructionToDeleteBook = _instructionService.ReturnInstructionsToDeleteBook();
            _displayMessageService.WriteResult(instructionToDeleteBook);
            var bookIdInput = _displayMessageService.ReadCommand();
            _bookService.DeleteBook(bookIdInput);
            //TODO:MESSAGES FOR error
        }

        public void BorrowBook()
        {
            Dictionary<string, string> customerDataInput = new Dictionary<string, string>();
            string instructionToBorrowBook = _instructionService.ReturnInstructionsToBorrowBook();
            string[] customerData = _instructionService.ReturnCustomerFieldsToCreateCustomer();
            string estimatedReturnDate = _instructionService.ReturnEstimatedReturnDateInstructions();
            string bookIds = _instructionService.ReturnInstructionsForIdsOfBooks();

            _displayMessageService.WriteResult(instructionToBorrowBook);
            foreach (var data in customerData)
            {
                _displayMessageService.WriteResult(data);
                var input = _displayMessageService.ReadCommand().Trim().ToLower();
                customerDataInput.Add(data, input);
            }
            _displayMessageService.WriteResult(estimatedReturnDate);
            var estimatedReturnDateInput = _displayMessageService.ReadCommand().Trim().ToLower();
            _displayMessageService.WriteResult(bookIds);
            var bookIdsInput = _displayMessageService.ReadCommand().Trim().ToLower().Split(",");
            _bookService.BorrowBook(bookIdsInput, customerDataInput, estimatedReturnDateInput);
        }

        public void ReturnBook()
        {
            string instructionsToReturnBook = _instructionService.ReturnInstructionsToReturnBook();
            _displayMessageService.WriteResult(instructionsToReturnBook);
            var bookIdInput = _displayMessageService.ReadCommand();
            _bookService.ReturnBook(bookIdInput);
        }
    }
}
