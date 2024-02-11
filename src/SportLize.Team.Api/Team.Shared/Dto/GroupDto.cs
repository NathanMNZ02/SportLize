using SportLize.Team.Api.Team.Repository.Model;
using SportLize.Team.Api.Team.Repository.Enumeration;

namespace SportLize.Team.Api.Team.Shared.Dto
{
    public class GroupWriteDto
    {
        public string Name { get; set; } = string.Empty;
        public GroupState GroupState { get; set; }
    }

    public class GroupReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public GroupState GroupState { get; set; }
    }
}
