using ApiGraphQL.Models;
using GraphQL.Types;

namespace ApiGraphQL.GraphQL.Mutation
{
    public partial class GraphMutation
    {
        private void InitOrder()
        {
            FieldAsync<OrderGraphType>("deleteOrder", "删除订单",
                new QueryArguments
                {
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = nameof(Order.Id), Description = "订单的Id" }
                },
                context =>
                {
                    throw new System.NotImplementedException();
                });
        }
    }
}
