using ApiGraphQL.Models;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace ApiGraphQL.GraphQL
{
    public class OrderDetailGraphType : ObjectGraphType<OrderDetail>
    {
        public OrderDetailGraphType()
        {
            Name = nameof(OrderDetail);
            Description = "OrderDetail";

            Field<NonNullGraphType<IdGraphType>>(nameof(OrderDetail.Id), "OrderDetail 的 Id");

            Field<NonNullGraphType<StringGraphType>>(nameof(OrderDetail.Name), "OrderDetail 的名称");

            FieldAsync<OrderGraphType>(nameof(OrderDetail.Order), "OrderDetail 所属的 Order", resolve: async context =>
            {
                using var dbContext = context.RequestServices.GetService<AppDbContext>();
                return await dbContext.Orders.Where(o => o.Id == context.Source.OrderId).ToListAsync();
            });
        }
    }
}
