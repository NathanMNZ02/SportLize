
using SportLize.Team.Api.Team.Repository.Enumeration;

namespace SportLize.Team.Api.Team.Repository.Model
{
    public class UserKafka
    {
        public int Id { get; set; }
        public Actor Actor { get; set; }
        public required string Nickname { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Password { get; set; }
        public required string Description { get; set; }
        public required DateTime DateOfBorn { get; set; }


        //Navigation
        public int GroupId { get; set; }
        public Group? Group { get; set; }
    }
}
