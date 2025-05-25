using HotChocolate;
using HotChocolate.Types;
using MediatR;
using SimpleShop.Application.Features.Orders.CreateOrder;

namespace SimpleShop.Api.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class OrderMutations
{
    public async Task<Guid> CreateOrderAsync(
        CreateOrderCommand input,
        [Service] ISender sender,
        CancellationToken cancellationToken)
    {
        return await sender.Send(input, cancellationToken);
    }
}