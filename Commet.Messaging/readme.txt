   
        )     *                  (       *     (     
   (   ( /(   (  `          *   )  )\ )  (  `    )\ )  
   )\  )\())  )\))(   (   ` )  /( (()/(  )\))(  (()/(  
 (((_)((_)\  ((_)()\  )\   ( )(_)) /(_))((_)()\  /(_)) 
 )\___  ((_) (_()((_)((_) (_(_()) (_))  (_()((_)(_))   
((/ __|/ _ \ |  \/  || __||_   _| / __| |  \/  |/ __|  
 | (__| (_) || |\/| || _|   | | _ \__ \ | |\/| |\__ \  
  \___|\___/ |_|  |_||___|  |_|(_)|___/ |_|  |_||___/  
                                                       

COMET.SMS
This is a lightweight library for working with SMS in .Net currently build for Hubtel Support.
*Send Single SMS
*Send Bulk SMS
*Send SMS From CSV
*Optional Logging TxtFile
*Validate Local Mobile Numbers(Ghanain (+233), 10)


Using the libray... :-)



			
private static void Main(string[] args)
 {	
	/Fetch Your Keys From  App Settings for Security 
      ClientCredentials.ClientId = ConfigurationSettings.AppSettings["ClientId"];
      ClientCredentials.ClientSecret = ConfigurationSettings.AppSettings["ClientSecret"];

    //Enable Logging- THis will be output to a .txt file
      MessageLogger.EnableLogging = true;
      MessageLogger.LogPath = "";


    //Get your phone Numbers .ToList() from your database, for demo purpose i am building the list
      List< string > myphone = new List<string>();
      myphone.Add("0266275605");
      myphone.Add("0266275605");
      myphone.Add("0266111");

      //Add list of Phone Numbers
      Phone.PhoneNumbers = myphone;
      //Configure and use the MessageClient to Send your Messages
      MessageClient msg = new MessageClient("Testing", "Testing Bulk SMS", true);
      msg.SendBulkSMS();

      Console.WriteLine("Done...");
      Console.ReadKey();
	}

Contribute :
follow developer twitter: @mr_odoom github: