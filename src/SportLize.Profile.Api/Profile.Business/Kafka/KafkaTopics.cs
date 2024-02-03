using Microsoft.Extensions.DependencyInjection;

namespace SportLize.Profile.Api.Profile.Business.Kafka
{
	public class KafkaTopics 
	{
		public string User { get; set; } = "User";
		public IEnumerable<string> GetTopics() => new List<string>() { User };
	}
}

