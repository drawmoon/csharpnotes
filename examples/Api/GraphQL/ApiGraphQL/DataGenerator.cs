using ApiGraphQL.Models;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiGraphQL
{
    public static class DataGenerator
    {
        public static void InitSampleData(IServiceProvider serviceProvider)
        {
            using var dbContext = serviceProvider.GetService<AppDbContext>();

            var data = File.ReadAllText("./sample-data.json", Encoding.UTF8);
            var orders = JsonConvert.DeserializeObject<List<Order>>(data);

            dbContext.Orders.AddRange(orders);

            dbContext.SaveChanges();
        }
    }
}
