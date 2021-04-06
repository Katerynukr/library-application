using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BorrowDate { get; set; }
    }
}
