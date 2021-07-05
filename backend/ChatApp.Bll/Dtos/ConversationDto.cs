using System.Collections.Generic;

namespace ChatApp.Bll.Dtos
{
    public class ConversationDto
    {
        public int Id { get; set; }
        public string PartnerUserName { get; set; }
        public List<MessageDto> Messages { get; set; }
    }
}
