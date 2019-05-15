using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace netcore2_mongodb.Repository
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
