using LibraryApplication.Loggers;
using LibraryApplication.Models;
using LibraryApplication.Services.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class BookReturnControlService
    {
        private readonly ErrorService _errorService;

        public BookReturnControlService()
        {
            _errorService = new ErrorService();
        }

        public string CheckWasReturnDelayed(Book book)
        {
            var currentDate = DateTime.Now;
            var borrowDate = book.Customer.BorrowDate;
            int daysBookWasBorrowed = (currentDate - borrowDate).Days;
            if( daysBookWasBorrowed > 60)
            {
                return _errorService.ReturnDelayedReturnErrorMessage();
            }
            throw new Exception("You returned the book with dalay");
        }
    }
}
