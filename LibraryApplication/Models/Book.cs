﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Models
{
    public class Book
    {
        public string Name { get; set; }
        public string[] Author { get; set; }
        public string[] Category { get; set; }
        public string Language { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public Customer Customer { get; set; }
        public bool IsTaken = false;

    }
}
