using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportLize.Profile.Api.Profile.Repository.Model
{
	public class Post
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		public required byte[] Media { get; set; }
		public required int Like { get; set; }
		public required DateTime PubblicationDate { get; set; }

		public string? Description;

		//Comment Mapping
		public List<Comment>? Comments;

		//User Mapping
		public required User User { get; set; }
		public required int UserId { get; set; }

		//PostInterest Mapping
        public PostInterest? PostInterest { get; set; } //Inizialmente a null, poi verranno inseriti sempre in fase di creazione
        public int? PostInterestId { get; set; }
    }
}

