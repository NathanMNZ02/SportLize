namespace SportLize.Team.Api.Team.Business.Kafka
{
    public class KafkaTopicsInput : AbstractKafkaTopics
    {
        public string User { get; set; } = "User";
        public override IEnumerable<string> GetTopics() => new List<string>() { User };
    }
}
