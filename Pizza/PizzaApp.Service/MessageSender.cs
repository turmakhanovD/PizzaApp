using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace RegistrationSystem
{
    public class MessageSender
    {
        private const string accountSid = "AC93c72a6eab816454ccf6169925d1675e";
        private const string authToken = "43ebc6c78dceaff83bb68e75b890a033";


        public void SendMessage(string _phoneNumber, int _code)
        {
            TwilioClient.Init(accountSid, authToken);
            try
            {
                var message = MessageResource.Create(
                    body: "Your code: " + _code,
                    from: new Twilio.Types.PhoneNumber("+1 877 740 8767"),
                    to: new Twilio.Types.PhoneNumber(_phoneNumber)
                );
            }
            catch
            {
                Console.WriteLine("You should write your phone in this format (+N NNN NNN NN NN)");

            }
        }
    }
}