using SportLize.Talk.Api.Talk.Repository.Enumeration;

namespace SportLize.Talk.Api.Talk.Repository.Model
{
    public class UserKafka
    {
        public int Id { get; set; }
        public Actor Actor { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateOfBorn { get; set; } = DateTime.UtcNow;

        //Navigation Chat
        public List<Chat> Chats { get; set; } = new List<Chat>();
    }
}
