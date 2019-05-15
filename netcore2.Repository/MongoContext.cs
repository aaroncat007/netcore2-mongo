using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace netcore2.Repository
{
    public class MongoContext : IMongoContext
    {
        public IMongoDatabase Database { get; private set; }
        private readonly List<Func<Task>> _commands;

        public MongoContext(string connectionString)
        {
            // Set Guid to CSharp style (with dash -)
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            // Every command will be stored and it'll be processed at SaveChanges
            _commands = new List<Func<Task>>();

            RegisterConventions();

            var url = new MongoUrl(connectionString);

            // Configure mongo (You can inject the config, just to simplify)
            var mongoClient = new MongoClient(connectionString);

            Database = mongoClient.GetDatabase(url.DatabaseName ?? "default");
        }

        private void RegisterConventions()
        {
            var pack = new ConventionPack
                    {
                        new IgnoreExtraElementsConvention(true),
                        new IgnoreIfDefaultConvention(true)
                    };
            ConventionRegistry.Register("My Solution Conventions", pack, t => true);
        }
    }
}
