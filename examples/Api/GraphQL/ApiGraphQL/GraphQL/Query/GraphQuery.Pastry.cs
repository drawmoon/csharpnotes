using ApiGraphQL.GraphQL;
using GraphQL.Types;

namespace ApiGraphQL.GraphQL.Query
{
    public partial class GraphQuery
    {
        private void InitPastryQuery()
        {
            Field<ListGraphType<PastryGraphType>>("Pastrys", "获取 Pastry",
                resolve: context =>
                {
                    throw new System.NotImplementedException();
                });
        }
    }
}
