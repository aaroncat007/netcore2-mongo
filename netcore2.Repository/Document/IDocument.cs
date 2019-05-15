using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace netcore2.Repository.Document
{
    public interface IDocument
    {
        ObjectId Id { get; set; }
    }
}
