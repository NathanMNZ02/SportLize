using System;
using System.ComponentModel.DataAnnotations.Schema;
using SportLize.Profile.Api.Profile.Repository.Enumeration;

namespace SportLize.Profile.Api.Profile.Repository.Model
{
	public class User
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		public required Actor Actor { get; set; }
		public required string Nickname { get; set; }
		public required string Name { get; set; }
		public required string Surname { get; set; }
		public required string Password { get; set; }
		public required string Description { get; set; }
        public required DateTime DateOfBorn { get; set; }

		//Interest Mapping
		public UserInterest? UserInterest { get; set; } //Inizialmente a null, poi verranno inseriti sempre in fase di creazione
        public int? UserInterestId { get; set; }


        //Followers Mapping
        public List<User> Followers { get; } = new List<User>();
        public List<User> Following { get; } = new List<User>();

        //Post Mapping
        public List<Post>? Posts { get; set; }
	}
}

