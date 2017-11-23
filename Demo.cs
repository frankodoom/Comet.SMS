using Smsgh.Api.Sdk.Smsgh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Comet.SMS
{
    internal class Demo
    { 
        private static void Main(string[] args)
        {

            //Fetch Your Keys From App Settings for Security 
            ClientCredentials.ClientId = ConfigurationSettings.AppSettings["ClientId"];
            ClientCredentials.ClientSecret = ConfigurationSettings.AppSettings["ClientSecret"];

            ///Enable Logging- This will be output to a .txt file
            // MessageLogger.EnableLogging = false;
            ///Specify Path for logfile, file will be created if it doesnt exist
            // MessageLogger.LogPath = "@/output.txt";

            //Remove 0 and add +233 to the beginning of the phone numbers
            Phone.FormatLocal = true;

            //Get your phone Numbers .ToList() from your database, for demo purpose i am building the list
            List<string> myphone = new List<string>();
            myphone.Add("066275605");
          
            //Add list of Phone Numbers
            Phone.PhoneNumbers = myphone;
            
            // Configure and use the MessageClient to Send your Messages
            MessageClient msg = new MessageClient("SMSBOT", "Hello Cometter!", true);  
            
            //Call SendSMSAsync to Send your SMS
            var sent = msg.SendSMSAsync();
            sent.Dispose();

            Console.WriteLine("Done...");
            Console.ReadKey();
        }
    }

}
