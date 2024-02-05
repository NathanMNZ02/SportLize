namespace SportLize.Talk.Api.Talk.Repository.Model
{
    public class Chat
    {
        public required int From { get; set; } //Chiamata con kafka per ottenere User
        public required int To { get; set; } //Chiamata con kafka per ottenere User

        //Navigation Message
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
