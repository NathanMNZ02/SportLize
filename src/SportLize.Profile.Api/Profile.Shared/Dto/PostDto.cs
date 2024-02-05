namespace SportLize.Profile.Api.Profile.Shared.Dto
{
    public class PostWriteDto
    {
        public byte[] Media { get; set; } = new byte[0];
        public int Like { get; set; }
        public DateTime PubblicationDate { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public class PostReadDto
    {
        public int Id { get; set; }
        public byte[] Media { get; set; } = new byte[0];
        public int Like { get; set; }
        public DateTime PubblicationDate { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
