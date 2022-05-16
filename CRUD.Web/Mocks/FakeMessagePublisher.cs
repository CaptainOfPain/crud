using PlaygroundShared.IntercontextCommunication.Messages;
using PlaygroundShared.Messages;

namespace CRUD.Web.Mocks;

public class FakeMessagePublisher : IMessagePublisher
{
    private readonly ILogger<FakeMessagePublisher> _logger;

    public FakeMessagePublisher(ILogger<FakeMessagePublisher> logger)
    {
        _logger = logger;
    }
    
    public Task Publish(IMessage message)
    {
        _logger.LogInformation($"Event: {message.GetType().Name}");
        
        return Task.CompletedTask;
    }
}