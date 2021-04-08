using LibraryApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class DisplayMessageService
    {
        private ILogger _logger;
        public DisplayMessageService(ILogger logger)
        {
            _logger = logger;
        }

        public void WriteResult(string input)
        {
            _logger.Write(input);
        }

        public string ReadCommand()
        {
            string input = _logger.Read();
            return input;
        }
    }
}
