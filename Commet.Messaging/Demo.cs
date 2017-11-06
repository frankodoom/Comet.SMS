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

            //Enable Logging- This will be output to a .txt file
            MessageLogger.EnableLogging = true;
            //Optional Log to text Feature: create a .txt file and point to path        
           // MessageLogger.LogPath = "@/output.txt";

            //Get your phone Numbers .ToList() from your database, for demo purpose i am building the list

            List<string> myphone = new List<string>();
            myphone.Add("0266275601");
            myphone.Add("0266271201");
            myphone.Add("0266271231");
            myphone.Add("0266111");
            

            //Add list of Phone Numbers
            Phone.PhoneNumbers = myphone;
            // Configure and use the MessageClient to Send your Messages
            MessageClient msg = new MessageClient("Accede", "Testing Bulk SMS", true);
            msg.SendBulkSMSAsync();
            Console.WriteLine("Done...");
            Console.ReadKey();        
        }
    }

}
