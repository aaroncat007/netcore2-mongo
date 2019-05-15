using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace netcore2_mongodb.Repository
{
    public abstract class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 主鍵名稱
        /// </summary>
        private const string ObjectID = "_id";

        private IMongoCollection<TEntity> Collection { get; }
        private IMongoDatabase Database { get; }

        protected MongoRepository(IMongoContext context)
        {
            Database = context.Database;
            Collection = Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public void Add(TEntity item)
        {
            Collection.InsertOne(item);
        }

        public Task AddAsync(TEntity item)
        {
            return Collection.InsertOneAsync(item);
        }

        public void AddRange(IEnumerable<TEntity> list)
        {
            Collection.InsertMany(list);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> list)
        {
            return Collection.InsertManyAsync(list);
        }

        public bool Any()
        {
            return Collection.Find(new BsonDocument()).Any();
        }

        public bool Any(Expression<Func<TEntity, bool>> where)
        {
            return Collection.Find(where).Any();
        }

        public Task<bool> AnyAsync()
        {
            return Collection.Find(new BsonDocument()).AnyAsync();
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> where)
        {
            return Collection.Find(where).AnyAsync();
        }

        public long Count()
        {
            return Collection.CountDocuments(new BsonDocument());
        }

        public long Count(Expression<Func<TEntity, bool>> where)
        {
            return Collection.CountDocuments(where);
        }

        public Task<long> CountAsync()
        {
            return Collection.CountDocumentsAsync(new BsonDocument());
        }

        public Task<long> CountAsync(Expression<Func<TEntity, bool>> where)
        {
            return Collection.CountDocumentsAsync(where);
        }

        public void Delete(object key)
        {
            Collection.DeleteOne(FilterId(key));
        }

        public void Delete(Expression<Func<TEntity, bool>> where)
        {
            Collection.DeleteMany(where);
        }

        public Task DeleteAsync(object key)
        {
            return Collection.DeleteOneAsync(FilterId(key));
        }

        public Task DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            return Collection.DeleteManyAsync(where);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> where)
        {
            return Collection.Find(where).FirstOrDefault();
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> where)
        {
            return Collection.Find(where).FirstOrDefaultAsync();
        }

        public IEnumerable<TEntity> List()
        {
            return Collection.Find(new BsonDocument()).ToList();
        }

        public IEnumerable<TEntity> List(Expression<Func<TEntity, bool>> where)
        {
            return Collection.Find(where).ToList();
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where)
        {
            return await Collection.Find(where).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await Collection.Find(new BsonDocument()).ToListAsync().ConfigureAwait(false);
        }

        public TEntity Find(object key)
        {
            return Collection.Find(FilterId(key)).SingleOrDefault();
        }

        public Task<TEntity> FindAsync(object key)
        {
            return Collection.Find(FilterId(key)).SingleOrDefaultAsync();
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> where)
        {
            return Collection.Find(where).SingleOrDefault();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> where)
        {
            return Collection.Find(where).SingleOrDefaultAsync();
        }

        public void Update(TEntity item, object key)
        {
            Collection.ReplaceOne(FilterId(key), item);
        }

        public Task UpdateAsync(TEntity item, object key)
        {
            return Collection.ReplaceOneAsync(FilterId(key), item);
        }

        private static FilterDefinition<TEntity> FilterId(object key)
        {
            return Builders<TEntity>.Filter.Eq(ObjectID, ObjectId.Parse(key.ToString()));
        }
    }
}
