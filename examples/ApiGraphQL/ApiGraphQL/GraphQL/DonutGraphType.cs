using ApiGraphQL.Models;
using GraphQL.Types;

namespace ApiGraphQL.GraphQL
{
    public class DonutGraphType : AbstractPastryGraphType<Donut>
    {
        public DonutGraphType()
        {
            Name = nameof(Donut);
            Description = "";

            Field<NonNullGraphType<IntGraphType>>(nameof(Donut.Id));

            Field<NonNullGraphType<StringGraphType>>(nameof(Donut.Name));
        }
    }
}
