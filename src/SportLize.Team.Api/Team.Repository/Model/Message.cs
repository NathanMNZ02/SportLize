namespace SportLize.Team.Api.Team.Repository.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }

        //Navigation Group
        public int GroupId { get; set; }
        public Group? Group { get; set; }

        //Navigation User
        public int UserId { get; set; }
        public UserKafka? UserKafka { get; set; }
    }
}
