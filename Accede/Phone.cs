using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comet.SMS
{
    //In memory Phone Objects for recieveing phone numbers
    public abstract class Phone : IDisposable
    {
        //Temp Hold List of Numbers
        public static List<string> PhoneNumbers;
        //Ghanaian Mobile Number Formatting Setting
        public static bool FormatLocal = false;

        //Temp Hold Name and Phone Number
        public static Dictionary<string, string> PhoneBook = new Dictionary<string, string>();

        //Override validation to allow custom Phone Number Validation
        public abstract string CustomValidate(string Phone);


        public static string Validate(string phone)
        {
            int requiredPhoneLength = phone.Length - 1;
            // formatting with Ghana Country code
            string newPhone = "+233" + phone.Substring(1, requiredPhoneLength);

            if (MessageLogger.EnableLogging == true)
            {
                MessageLogger.LogStatus(MessageLogger.LogPath, "Formatted  " + phone + " to " + newPhone);
            }
  
            return newPhone;
        }

        //Write a generic Save using Entity
        //public abstract void Save(T<Entity>);

        public void Dispose()
        {
            
        }
    }


}
