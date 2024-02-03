using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportLize.Profile.Api.Profile.Repository.Model
{
	public class Comment
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		public required string Text { get; set; }
		public required int Like { get; set; }
		public required DateTime PubblicationDate { get; set; }

        //Post mapping
        public required Post Post { get; set; }
        public required int PostId { get; set; }
    }
}

