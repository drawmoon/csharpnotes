using ApiGraphQL.Models;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ApiGraphQL.GraphQL
{
    public class OrderGraphType : ObjectGraphType<Order>
    {
        public OrderGraphType()
        {
            Name = nameof(Order);
            Description = "Order";

            Field<NonNullGraphType<IdGraphType>>(nameof(Order.Id), "Order 的 Id");

            Field<NonNullGraphType<StringGraphType>>(nameof(Order.Name), "Order 的名称");

            FieldAsync<ListGraphType<OrderDetailGraphType>>(nameof(Order.OrderDetails), "Order 的 OrderDetail", resolve: async context =>
            {
                using var dbContext = context.RequestServices.GetService<AppDbContext>();
                return await dbContext.OrderDetails.Where(o => o.OrderId == context.Source.Id).ToListAsync();
            });
        }
    }
}
