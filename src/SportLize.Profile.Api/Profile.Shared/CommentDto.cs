using SportLize.Profile.Api.Profile.Repository.Model;

namespace SportLize.Profile.Api.Profile.Shared
{
    public class CommentDto
    {
        public int Id { get; set; }
        public required string Text { get; set; }
        public required int Like { get; set; }
        public required DateTime PubblicationDate { get; set; }
        public required int PostId { get; set; }
    }
}