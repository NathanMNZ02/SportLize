using System;
namespace SportLize.Profile.Api.Profile.Shared
{
	public class PostDto
	{
        public int Id { get; set; }
        public required string MediaBase64 { get; set; }
        public required int Like { get; set; }
        public required DateTime PubblicationDate { get; set; }
        public required int UserId { get; set; }
        public string? Description { get; set; }
    }
}

