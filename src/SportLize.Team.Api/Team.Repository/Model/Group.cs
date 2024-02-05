using SportLize.Team.Api.Team.Repository.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportLize.Team.Api.Team.Repository.Model
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public GroupState GroupState { get; set; }


        //Navigation Component
        public List<UserKafka> UsersKafka { get; set; } = new List<UserKafka>(); 

        //Navigation Message
        public List<Message> Messages { get; set; } = new List<Message>();   
    }
}
