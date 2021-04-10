using LibraryApplication.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApplication.Services
{
    public class FileService
    {
        private const string path = @"Data\BooksList.json";
        public IEnumerable<Book> ParseFromJsonFile()
        {
            if (path != null)
            {
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    IEnumerable<Book> books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
                    return books;
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
        public void ParseToJsonFile(List<Book> newBooksList)
        {
            try
            {
                File.WriteAllText(@"C:\Users\kater\Documents\dot-net\LibraryApplication\LibraryApplication\Data\BooksList.json", JsonConvert.SerializeObject(newBooksList));
            }
            catch (Exception )
            {
            }
        }
    }
}
