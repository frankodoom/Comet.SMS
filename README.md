; #  Documentation
This libray aims at making sending of bulk SMS simple. Currently supporting Hubtel .NET SDK you can follow the steps below to send
bulk SMS from your applications with a detailed logger.

```cs
    //Enable Logging- This will be output to a .txt file
      MessageLogger.EnableLogging = true;
    //Specify your Environment path to your .txt, the .txt will be created automatically if it doesnt exist
      MessageLogger.LogPath = myPath;
```
#### Supplying Contact List for Bulk SMS
* From List
```cs
     //Get your phone Numbers .ToList() from your database, for demo purpose i am building the list
       List<string> phoneNumbers = new List<string>();
       myphone.Add("0266275605");
       myphone.Add("0266275611");
       myphone.Add("0246684091");
       myphone.Add("0266111"); //This is an invalid Number and will be saved to outbox.
  ``` 
* From Database
 ```cs
      // Select the List of Phone Numbers to send from Database using Entity
      var phoneNumbers = _context.Employees.Select(p => p.PhoneNumber).ToList();
 ```   
 
   * Add list to PhoneNumbers for sending 
  ```cs
     //PhoneNumber is an Inmemory Object List<string>Phonebook
     Phone.PhoneNumbers = phoneNumbers;
 ```    

  
   * From .Csv File. 
    You can send bulk sms from a .csv file with two columns eg. Name & Phone
  ```cs
   //Extract the .CSV to PhoneBook Dictionary
    CSVReader.ExtractContacts(myPatth)     
   //Access the PhoneBook Dictionary for your Extracted COntacts 
    var myContacts = Phone.PhoneBook.ToList();
    //Iterate over dictionary and get 
  ```

  #### Configure and use the MessageClient to Send your Messages
   * Supply your keys from web.Config or App.Settings. Note: This is a more Secure Approach
```cs   
    ClientCredentials.ClientId = ConfigurationSettings.AppSettings["ClientId"];
    ClientCredentials.ClientSecret = ConfigurationSettings.AppSettings["ClientSecret"];
   ```  
   * Supply your clientSecrete and Keys Directly.
  ```cs  
  
    ClientCredentials.ClientId ="myClientId" ;
    ClientCredentials.ClientSecret ="myClientSecret";
 ``` 
   * Send Bulk SMS
 ```cs  
    MessageClient msg = new MessageClient("Testing", "Testing Bulk SMS", true); 
   //Send Your Message
    msg.SendBulkSMS();
  ```   
  * Accessing Sent Messages
```cs
    //Get List of Sent Messages
     var sentMessages = MessageLogger.sent.ToList();
    //you can iterate over object and save the list to database
```   

  * Accessing UnDelivered Messages
 ```cs
    //All unsent messages in a batch can be accessed in the outbox object
    MessageLogger.outbox.ToList();
    // you can iterate over object and save the list to database
 ```    
