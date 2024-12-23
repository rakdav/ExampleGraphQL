using ExampleGraphQL.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace ExampleGraphQL.Data
{
    public class Subscription
    {
        [Subscribe]
        public async ValueTask<ISourceStream<Post>> OnPostCreate([Service] ITopicEventReceiver eventReceiver,
            CancellationToken cancellationToken)
        {
            return await eventReceiver.SubscribeAsync<Post>("PostCreated", cancellationToken);
        }
    }
}
