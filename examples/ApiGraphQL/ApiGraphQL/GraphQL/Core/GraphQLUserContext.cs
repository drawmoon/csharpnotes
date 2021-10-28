using System.Collections.Generic;
using System.Security.Claims;

namespace ApiGraphQL.GraphQL.Core
{
    public class GraphQLUserContext : Dictionary<string, object>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
