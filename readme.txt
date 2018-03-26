
        )     *                  (       *     (     
   (   ( /(   (  `          *   )  )\ )  (  `    )\ )  
   )\  )\())  )\))(   (   ` )  /( (()/(  )\))(  (()/(  
 (((_)((_)\  ((_)()\  )\   ( )(_)) /(_))((_)()\  /(_)) 
 )\___  ((_) (_()((_)((_) (_(_()) (_))  (_()((_)(_))   
((/ __|/ _ \ |  \/  || __||_   _| / __| |  \/  |/ __|  
 | (__| (_) || |\/| || _|   | | _ \__ \ | |\/| |\__ \  
  \___|\___/ |_|  |_||___|  |_|(_)|___/ |_|  |_||___/  
                                                       

An Easy to use .NET Bulk SMS Library 



 ```private static void Main(string[] args)

        {

            //Fetch Your Keys From App Settings for Security 

            ClientCredentials.ClientId = ConfigurationSettings.AppSettings["ClientId"];

            ClientCredentials.ClientSecret = ConfigurationSettings.AppSettings["ClientSecret"];

            //Enable Logging- This will be output to a .txt file

            MessageLogger.EnableLogging = true;

            ///Specify Path for logfile, file will be created if it doesnt exist

            // MessageLogger.LogPath = "@/output.txt"

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
    }```




Supported Providers:
HUbtel

