using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChatApp.Api.Controllers
{
    [Route("messages")]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
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
