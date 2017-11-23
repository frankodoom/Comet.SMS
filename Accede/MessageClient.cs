using Comet.SMS.Service.Interface;
using System;
using Smsgh.Api.Sdk.Smsgh;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comet.SMS
{
    public class MessageClient : IMessageClient, IDisposable
    {
        public string MessageBody { get; set; }
        public string MessageId { get; set; }
        public string DeliveryReciept { get; set; }
        public bool RegisteredDelivery { get; set; }


        public MessageClient(string messageId, string message, bool registerdDelivery)
        {
            MessageBody = message;
            MessageId = messageId;
            RegisteredDelivery = registerdDelivery;
        }

        public Task SendSMSAsync()
        {         
            return Task.FromResult(doSMSJob());
        }


        public int doSMSJob()
        {
            string formattedPhone = "";

            var host = new ApiHost(new BasicAuth(ClientCredentials.GetClientId(), ClientCredentials.GetSecret()));
            if(MessageLogger.EnableLogging == true)
            {
                MessageLogger.LogStatus(MessageLogger.LogPath, "Starting New Batch.............................................................");
                MessageLogger.LogStatus(MessageLogger.LogPath, "Establishing Server Connection");
                
            }
          
            var messageApi = new MessagingApi(host);


            foreach (var phone in Phone.PhoneNumbers)
            {

                if (MessageLogger.EnableLogging == true)
                {
                    MessageLogger.LogStatus(MessageLogger.LogPath, "Sending to........ " + phone);
                }

                //Remove 0 and add +233 to the beginning of the phone numbers
                if (Phone.FormatLocal == true)
                {
                    formattedPhone = Phone.Validate(phone);
                }
             
                //checking the Ghanaian standard mobile length
                if (phone.Length < 10)
                {
                    // log unsent message to outBox 
                    MessageLogger.logOutbox(formattedPhone, "Rejected due to length < 10");
                    continue;
                }
                else
                {
                    try
                    {
                        MessageResponse msge = messageApi.SendQuickMessage(MessageId, formattedPhone, MessageBody, RegisteredDelivery);
                        MessageLogger.logSent(formattedPhone, "Successful");
                    }
                    catch (Exception e)
                    {
                        MessageLogger.logOutbox(formattedPhone, "rejected due to server error !");
                        //pass control to the next iteration of the enclosing foreach statement
                        continue;
                    }
                }
            }
            //returns number of sent >1 when successful
            return MessageLogger.sent.Count; 
        }

        public void Dispose()
        {
            
        }
    }
}
    

