using SportLize.Talk.Api.Talk.Repository.Model;

namespace SportLize.Talk.Api.Talk.Shared.Dto
{
    public class ChatWriteDto
    {
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }

    public class ChatReadDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
    }
}
