using PlaygroundShared.Application.CQRS;
using PlaygroundShared.Domain.Domain;

namespace CRUD.Application.Items.Queries;

public class GetItemQuery : IQuery
{
    public AggregateId Id { get; }

    public GetItemQuery(AggregateId id)
    {
        Id = id;
    }
}