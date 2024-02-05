using Microsoft.Extensions.DependencyInjection;

namespace SportLize.Profile.Api.Profile.Business.Kafka
{
	public class KafkaTopics : AbstractKafkaTopics
	{
		public string User { get; set; } = "User";
        public override IEnumerable<string> GetTopics() => new List<string>() { User };
    }
}

