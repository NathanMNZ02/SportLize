using System;
using SportLize.Profile.Api.Profile.Repository.Enumeration;

namespace SportLize.Profile.Api.Profile.Shared
{
	public class UserDto
	{
        public int Id { get; set; }
        public required Actor Actor { get; set; }
        public required string Nickname { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Password { get; set; }
        public required string Description { get; set; }
        public required DateTime DateOfBorn { get; set; }
    }
}

