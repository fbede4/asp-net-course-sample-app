using System.Collections.Generic;

namespace ChatApp.Api.Services
{
    public interface IMessageService
    {
        List<string> GetMessages();
    }

    public class MockMessageService : IMessageService
    {
        public List<string> GetMessages()
        {
            return new List<string>
            {
                "Szia",
                "Szia",
                "Mizu?",
                "Semmi"
            };
        }
    }
}
