namespace SportLize.Talk.Api.Talk.Repository.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;

        //Navigation Chat
        public int ChatId { get; set; }
        public Chat? Chat { get; set; }
    }
}
