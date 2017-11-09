using Commet.Messaging.Service.Interface;
using System;
using Smsgh.Api.Sdk.Smsgh;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Commet.Messaging
{
    public class Message : IMessaging
    {
        public string Phone { get; set; }
        public string MessageBody { get; set; }
        public string MessageId { get; set; }
        public string DeliveryReciept { get; set; }
        public bool RegisteredDelivery { get; set; }
        public List<string> PhoneNumbers = new List<string>();



        public Message(string messageId, string phone, string message, bool registerdDelivery)
        {
            MessageBody = message;
            MessageId = messageId;
            Phone = phone;
            RegisteredDelivery = registerdDelivery;
        }

        public void SendBulkSMS()
        {
            var host = new ApiHost(new BasicAuth(ClientCredentials.GetClientId(), ClientCredentials.GetSecret()));
            var messageApi = new MessagingApi(host);
            MessageResponse msg = messageApi.SendQuickMessage(MessageId, Phone, MessageBody, RegisteredDelivery);
            Console.WriteLine("Message Sent Successfully to  " + Phone);
        }

        public void SendSingleMessage()
        {
            
        }



        //await Task.Run(() =>
        //    {
        //    try
        //    {

        //        MessageResponse msg = messageApi.SendQuickMessage(MessageId, Phone, MessageBody, RegisteredDelivery);
        //    }
        //    catch (Exception e)
        //    {
        //        e.Message.ToString();
        //    }
        //    //Console.WriteLine(msg.Status);

        //});
    }
}
    

