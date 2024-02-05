namespace SportLize.Team.Api.Team.Shared.Dto
{
    public class MessageWriteDto
    {
        public string Text { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }

    public class MessageReadDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
    }
}
