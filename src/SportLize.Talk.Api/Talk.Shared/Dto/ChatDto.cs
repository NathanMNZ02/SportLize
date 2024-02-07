using SportLize.Talk.Api.Talk.Repository.Model;

namespace SportLize.Talk.Api.Talk.Shared.Dto
{
    public class ChatWriteDto
    {
        public UserKafka From { get; set; } = new UserKafka();
        public UserKafka To { get; set; } = new UserKafka();
    }

    public class ChatReadDto
    {
        public int Id { get; set; }
        public UserKafka From { get; set; } = new UserKafka();
        public UserKafka To { get; set; } = new UserKafka();
    }
}
