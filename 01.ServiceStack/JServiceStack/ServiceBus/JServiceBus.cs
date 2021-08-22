using System;
using System.Threading.Tasks;
using eXtensionSharp;

namespace JServiceStack.ServiceBus
{
    public interface IServiceSender
    {
        Task SendMessageAsync(string message);
    }

    public class EmailServiceSender : IServiceSender
    {
        public Task SendMessageAsync(string message)
        {
            throw new System.NotImplementedException();
        }
    }

    public class SmsServiceSender : IServiceSender
    {
        public Task SendMessageAsync(string message)
        {
            throw new System.NotImplementedException();
        }
    }

    public class KakaoServiceSender : IServiceSender
    {
        public Task SendMessageAsync(string message)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class JServiceBus
    {
        private IServiceSender _serviceSender;

        public JServiceBus(IServiceSender sender)
        {
            _serviceSender = _serviceSender;
        }

        public async Task SendAsync(PayLoad payload)
        {
            var message = payload.xToJson();
            await this._serviceSender.SendMessageAsync(message).ConfigureAwait(false);
        }
    }

    public class Sample
    {
        public async Task Run()
        {
            var dto = new EmailSendDto();
            var payload = new PayLoad()
            {
                Host = "https://test.emailsender.com",
                Guid = Guid.NewGuid().ToString("N"),
                Message = dto
            };
            var sender = new EmailServiceSender();
            var serviceBus = new JServiceBus(sender);
            await serviceBus.SendAsync(payload).ConfigureAwait(false);
        }
    }

    public class PayLoad
    {
        public string Host { get; set; }
        public string Guid { get; set; }
        public object Message { get; set; }
    }

    public class EmailSendDto
    {
        public string Address { get; set; }
        public string SenderName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}