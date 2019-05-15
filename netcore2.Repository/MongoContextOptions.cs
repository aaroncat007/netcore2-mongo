using System;
using System.Collections.Generic;
using System.Text;

namespace netcore2_mongodb.Repository
{
    public class MongoContextOptions
    {
        public string ConnectionString { get; set; } = "mongodb://localhost/default";
    }
}
