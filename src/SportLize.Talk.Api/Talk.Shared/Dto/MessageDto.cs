namespace SportLize.Talk.Api.Talk.Shared.Dto
{
    public class MessageWriteDto
    {
        public string Text { get; set; } = string.Empty;
    }
    public class MessageReadDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
