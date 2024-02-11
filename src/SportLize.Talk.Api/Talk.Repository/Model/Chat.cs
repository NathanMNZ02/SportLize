namespace SportLize.Talk.Api.Talk.Repository.Model
{
    public class Chat
    {
        public int Id { get; set; }

        //Navigation Chat
        public int SenderId { get; set; }
        public UserKafka Sender { get; set; } = new UserKafka();
        public int ReceiverId { get; set; }
        public UserKafka Receiver { get; set; } = new UserKafka();

        //Navigation Message
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
