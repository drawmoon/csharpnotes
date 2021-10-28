using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RestApiOdata.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RestApiOdata
{
    public static class DataGenerator
    {
        public static void InitSampleData(IServiceProvider serviceProvider)
        {
            using var dbContext = serviceProvider.GetService<AppDbContext>();
            var text = File.ReadAllText("./sample-data.json", Encoding.UTF8);
            var users = JsonConvert.DeserializeObject<List<User>>(text);
            dbContext.AddRange(users);
            dbContext.SaveChanges();
        }
    }
}
