﻿using Microsoft.Extensions.Options;
using Utility.Kafka.Abstractions.MessageHandlers;
using Utility.Kafka.Services;

namespace SportLize.Team.Api.Team.Business.Kafka.MessageHandlers
{
    public class MessageHandlerFactory : IMessageHandlerFactory
    {
        private readonly ILogger<ConsumerService<KafkaTopicsInput>> _logger;
        private readonly KafkaTopicsInput _optionsTopics;

        public MessageHandlerFactory(ILogger<ConsumerService<KafkaTopicsInput>> logger, IOptions<KafkaTopicsInput> optionsTopics)
        {
            _logger = logger;
            _optionsTopics = optionsTopics.Value;
        }

        public IMessageHandler Create(string topic, IServiceProvider serviceProvider)
        {
            if (topic == _optionsTopics.User)
                return ActivatorUtilities.CreateInstance<UserKafkaMessageHandler>(serviceProvider);

            throw new ArgumentOutOfRangeException(nameof(topic), $"Il topic '{topic}' non è gestito");
        }
    }
}
