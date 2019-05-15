using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace netcore2.Repository
{
    public static class MongoContextExtensions
    {
        public static IServiceCollection AddMongoContextProvider(this IServiceCollection services, Action<MongoContextOptions> setupDatabaseAction)
        {
            var dbOptions = new MongoContextOptions();
            setupDatabaseAction(dbOptions);

            var builder = services.AddScoped<IMongoContext>(x => new MongoContext(dbOptions.ConnectionString));

            return builder;
        }
    }
}
