using Comet.SMS.Service.Interface;
using System;
using Smsgh.Api.Sdk.Smsgh;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comet.SMS
{
    public class MessageClient :  IMessageClient
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

        public void SendBulkSMS()
        {
            var host = new ApiHost(new BasicAuth(ClientCredentials.GetClientId(), ClientCredentials.GetSecret()));
            MessageLogger.LogStatus(MessageLogger.LogPath, "Configuring Client && Establishing Server Connection");
            var messageApi = new MessagingApi(host);

            foreach (var phone in Phone.PhoneNumbers)
            {
                MessageLogger.LogStatus(MessageLogger.LogPath, "Sending to........ "+ phone);
                //Remove 0 and add +233 to the beginning of the phone numbers
                string formattedPhone =Phone.Validate(phone);
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
                        //pass control to the next iteration of the enclosingforeach statement
                        continue;

                    }
                }          
            }
        }
        public void SendSMS()
        {
           //Sending Single SMS Code Goes Here
        }
    }
}
    

