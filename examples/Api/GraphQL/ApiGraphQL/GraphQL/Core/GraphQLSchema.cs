using ApiGraphQL.GraphQL.Mutation;
using ApiGraphQL.GraphQL.Query;
using GraphQL.Types;
using GraphQL.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ApiGraphQL.GraphQL.Core
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<GraphQuery>();
            Mutation = provider.GetRequiredService<GraphMutation>();

            // 使用接口类时，声明Schema有关特定类型的信息
            RegisterType(typeof(DonutGraphType));
        }
    }
}