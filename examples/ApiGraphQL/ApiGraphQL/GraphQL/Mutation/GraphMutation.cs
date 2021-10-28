using GraphQL.Types;

namespace ApiGraphQL.GraphQL.Mutation
{
    public partial class GraphMutation : ObjectGraphType<object>
    {
        public GraphMutation()
        {
            InitOrder();
        }
    }
}
