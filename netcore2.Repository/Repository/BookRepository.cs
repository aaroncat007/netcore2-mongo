﻿using netcore2_mongodb.Repository.Document;
using System;
using System.Collections.Generic;
using System.Text;

namespace netcore2_mongodb.Repository.Repository
{
    public interface IBookRepository : IRepository<Book> { }

    public class BookRepository : MongoRepository<Book>, IBookRepository
    {
        public BookRepository(IMongoContext context) : base(context) { }
    }
}
