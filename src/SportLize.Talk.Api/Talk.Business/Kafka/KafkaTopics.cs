
namespace SportLize.Talk.Api.Talk.Business.Kafka
{
    public class KafkaTopicsInput : AbstractKafkaTopics
    {
        public string User { get; set; } = "User";
        public override IEnumerable<string> GetTopics() => new List<string>() { User };
    }
}
