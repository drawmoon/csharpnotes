using GraphQL.Types;

namespace ApiGraphQL.GraphQL.Query
{
    public partial class GraphQuery : ObjectGraphType<object>
    {
        public GraphQuery()
        {
            Name = "Query";

            InitOrderQuery();
            InitOrderDetailQuery();
            InitPastryQuery();
        }
    }
}
