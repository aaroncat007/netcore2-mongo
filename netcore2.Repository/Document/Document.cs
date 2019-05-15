using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace netcore2_mongodb.Repository.Document
{
    public abstract class Document : IDocument
    {
        [BsonExtraElements]
        public BsonDocument ExtraElements { get; set; }

        public ObjectId Id { get; set; }
    }
}
