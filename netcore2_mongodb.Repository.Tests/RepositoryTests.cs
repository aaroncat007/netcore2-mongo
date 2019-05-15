using MongoDB.Bson;
using netcore2_mongodb.Repository;
using netcore2_mongodb.Repository.Document;
using netcore2_mongodb.Repository.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace netcore2_mongodb.Repository.Tests
{
    public class RepositoryTests
    {
        public IBookRepository BookRepository { get; private set; }

        [SetUp]
        public void Setup()
        {
            const string connectionString = "mongodb://test:123456@localhost:27017/test";
            var databaseContext = new MongoContext(connectionString);
            BookRepository = new BookRepository(databaseContext);
        }

        [Test]
        public void DatabaseTestsBookRepositoryAdd()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.Find(book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositoryAddAsync()
        {
            var book = CreateBook();
            BookRepository.AddAsync(book);
            Assert.IsNotNull(BookRepository.Find(book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositoryAddRange()
        {
            var count = BookRepository.Count();
            BookRepository.AddRange(new List<Book> { CreateBook() });
            Assert.IsTrue(BookRepository.Count() > count);
        }

        [Test]
        public void DatabaseTestsBookRepositoryAddRangeAsync()
        {
            var count = BookRepository.Count();
            BookRepository.AddRangeAsync(new List<Book> { CreateBook() });
            Assert.IsTrue(BookRepository.Count() > count);
        }

        [Test]
        public void DatabaseTestsBookRepositoryAny()
        {
            BookRepository.Add(CreateBook());
            Assert.IsTrue(BookRepository.Any());
        }

        [Test]
        public void DatabaseTestsBookRepositoryAnyAsync()
        {
            BookRepository.Add(CreateBook());
            Assert.IsTrue(BookRepository.AnyAsync().Result);
        }

        [Test]
        public void DatabaseTestsBookRepositoryAnyWhere()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsTrue(BookRepository.Any(x => x.Id == book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositoryAnyWhereAsync()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsTrue(BookRepository.AnyAsync(x => x.Id == book.Id).Result);
        }

        [Test]
        public void DatabaseTestsBookRepositoryCount()
        {
            BookRepository.Add(CreateBook());
            Assert.IsTrue(BookRepository.Count() > 0);
        }

        [Test]
        public void DatabaseTestsBookRepositoryCountAsync()
        {
            BookRepository.Add(CreateBook());
            Assert.IsTrue(BookRepository.CountAsync().Result > 0);
        }

        [Test]
        public void DatabaseTestsBookRepositoryCountWhere()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsTrue(BookRepository.Count(x => x.Id == book.Id) == 1);
        }

        [Test]
        public void DatabaseTestsBookRepositoryCountWhereAsync()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsTrue(BookRepository.CountAsync(x => x.Id == book.Id).Result == 1);
        }

        [Test]
        public void DatabaseTestsBookRepositoryDelete()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.Find(book.Id));
            BookRepository.Delete(book.Id);
            Assert.IsNull(BookRepository.Find(book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositoryDeleteAsync()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.Find(book.Id));
            BookRepository.DeleteAsync(book.Id);
            Assert.IsNull(BookRepository.Find(book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositoryDeleteWhere()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.Find(book.Id));
            BookRepository.Delete(x => x.Id == book.Id);
            Assert.IsNull(BookRepository.Find(book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositoryDeleteWhereAsync()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.Find(book.Id));
            BookRepository.DeleteAsync(x => x.Id == book.Id);
            Assert.IsNull(BookRepository.Find(book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositoryFirstOrDefault()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.FirstOrDefault(x => x.Id == book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositoryFirstOrDefaultAsync()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.FirstOrDefaultAsync(x => x.Id == book.Id).Result);
        }

        [Test]
        public void DatabaseTestsBookRepositoryList()
        {
            BookRepository.Add(CreateBook());
            Assert.IsTrue(BookRepository.List().Any());
        }

        [Test]
        public void DatabaseTestsBookRepositoryListAsync()
        {
            BookRepository.Add(CreateBook());
            Assert.IsTrue(BookRepository.ListAsync().Result.Any());
        }

        [Test]
        public void DatabaseTestsBookRepositoryListWhere()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsTrue(BookRepository.List(x => x.Id == book.Id).Any());
        }

        [Test]
        public void DatabaseTestsBookRepositoryListWhereAsync()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsTrue(BookRepository.ListAsync(x => x.Id == book.Id).Result.Any());
        }

        [Test]
        public void DatabaseTestsBookRepositorySelect()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.Find(book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositorySelectAsync()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.FindAsync(book.Id).Result);
        }

        [Test]
        public void DatabaseTestsBookRepositorySingleOrDefault()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.SingleOrDefault(x => x.Id == book.Id));
        }

        [Test]
        public void DatabaseTestsBookRepositorySingleOrDefaultAsync()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            Assert.IsNotNull(BookRepository.SingleOrDefaultAsync(x => x.Id == book.Id).Result);
        }

        [Test]
        public void DatabaseTestsBookRepositoryUpdate()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            var oldName = book.Name;
            book.Name = Guid.NewGuid().ToString();
            BookRepository.Update(book, book.Id);
            book = BookRepository.Find(book.Id);
            Assert.AreNotEqual(oldName, book.Name);
        }

        [Test]
        public void DatabaseTestsBookRepositoryUpdateAsync()
        {
            var book = CreateBook();
            BookRepository.Add(book);
            var oldName = book.Name;
            book.Name = Guid.NewGuid().ToString();
            BookRepository.UpdateAsync(book, book.Id);
            book = BookRepository.Find(book.Id);
            Assert.AreNotEqual(oldName, book.Name);
        }

        private static Book CreateBook()
        {
            return new Book { Id = ObjectId.GenerateNewId(), Name = Guid.NewGuid().ToString()};
        }
    }
}