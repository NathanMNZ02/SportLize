﻿
using SportLize.Team.Api.Team.Repository.Enumeration;

namespace SportLize.Team.Api.Team.Repository.Model
{
    public class UserKafka
    {
        public int Id { get; set; }
        public Actor Actor { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DateOfBorn { get; set; } = DateTime.UtcNow;


        //Navigation
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
