using LibraryApplication.Interfaces;
using LibraryApplication.Loggers;
using LibraryApplication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class UIService 
    {
        private readonly ConsoleLogger _consoleLogger;
        private readonly BookService _bookService;

        public UIService()
        {
            _consoleLogger = new ConsoleLogger();
            _bookService = new BookService();
        }

        public void DisplayCommands()
        {
            string availableCommands = InstructionHelpers.GetCommands();
            _consoleLogger.Write(availableCommands);
            
        }
        public string ReadCommands()
        {
            var command = _consoleLogger.Read().Trim().ToLower();
            return command;
        }

        
        public void GenerateBooksList()
        {
            var availableBooks = _bookService.GetAllBooks();
            availableBooks.ForEach(b => _consoleLogger.Write($"Id: {b.Id} Title: {b.Name} \n " +
                $"Author: {b.Author.Name} {b.Author.Surname}"));
        }

        public void AddNewBook()
        {
            var instructionForUser = InstructionHelpers.GetAddNewBookInstructions();
            var dataFieldsToCreateBook = InstructionHelpers.GetBookFields();
            Dictionary<string, string> userInputForNewBook = new Dictionary<string, string>();
            _consoleLogger.Write(instructionForUser);
            foreach (var bookField in dataFieldsToCreateBook)
            {
                _consoleLogger.Write(bookField);
                var input = _consoleLogger.Read().Trim().ToLower();
                userInputForNewBook.Add(bookField, input);
            }
            _bookService.AddNewBook(userInputForNewBook);
        }

        public void DeleteBook()
        {
            string instructionToDeleteBook = InstructionHelpers.GetDeleteBookInstruction();
            _consoleLogger.Write(instructionToDeleteBook);
            var bookIdInput = _consoleLogger.Read();
            _bookService.DeleteBook(bookIdInput);
        }

        public void BorrowBook()
        {
            Dictionary<string, string> customerDataInput = new Dictionary<string, string>();
            string instructionToBorrowBook = InstructionHelpers.GetReturnBookInstruction();
            string[] customerData = InstructionHelpers.GetCustomerFields();
            string bookIds = InstructionHelpers.GetIdsInstructions();

            _consoleLogger.Write(instructionToBorrowBook);
            foreach (var data in customerData)
            {
                _consoleLogger.Write(data);
                var input = _consoleLogger.Read().Trim().ToLower();
                customerDataInput.Add(data, input);
            }
            _consoleLogger.Write(bookIds);
            var bookIdsInput = _consoleLogger.Read().Trim().ToLower().Split(",");

            _bookService.BorrowBook(bookIdsInput, customerDataInput);
        }

        public void ReturnBook()
        {
            string instructionsToReturnBook = InstructionHelpers.GetReturnBookInstructions();
            _consoleLogger.Write(instructionsToReturnBook);
            var bookIdInput = _consoleLogger.Read();
             _bookService.ReturnBook(bookIdInput);
        }

        public void ExitLibrary()
        {
            _bookService.SaveChanges();
        }
    }
}
