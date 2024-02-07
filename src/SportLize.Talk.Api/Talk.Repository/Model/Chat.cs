namespace SportLize.Talk.Api.Talk.Repository.Model
{
    public class Chat
    {
        public int Id { get; set; }

        //Navigation Chat
        public int FromId { get; set; }
        public UserKafka From { get; set; } = new UserKafka();
        public int ToId { get; set; }
        public UserKafka To { get; set; } = new UserKafka();

        //Navigation Message
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
