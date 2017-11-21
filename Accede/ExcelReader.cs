using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Comet.SMS
{
   public class CsvReader
    { 
        //This CSV is Designed TO Load Two Columns customise it to laod many as you wish
        
        public int ExtractContacts(string dir, HttpPostedFileBase file)
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

                     //Add to  phone and number to phonebook
                      Phone.PhoneBook.Add(name, phone);
                    //TODO: LOg CSV Activity               
                }
            }
            return 1;
        }
    }
}
