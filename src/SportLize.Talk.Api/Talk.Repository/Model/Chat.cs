namespace SportLize.Talk.Api.Talk.Repository.Model
{
    public class Chat
    {
        public int Id { get; set; }

        //Navigation Chat
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        //Navigation Message
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
