using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Comet.SMS
{
   //
   public class CsvReader
    {           
        public int ExtractContacts(string dir)
        {
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), dir);
            string path = Environment.CurrentDirectory + dir;
            using (var reader = new StreamReader(path))
            {             
                while (!reader.EndOfStream)
                {    
                     var line = reader.ReadLine();
                     var values = line.Split(',');
                     var name = values[0];
                     var phone = values[1];

                     //Add to phonebook
                      Phone.PhoneBook.Add(name, phone);
                     //You can save phonebook to database from her                  
                }
            }
            return 1;
        }
    }
}
