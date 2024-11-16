using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace Airport.Services
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Airport.Services
    {
        public class CanceledFlightsService<T>
        {
            private readonly IMongoCollection<BsonDocument> _canceledFlightsCollection;

            public CanceledFlightsService(string collectionName)
            {
                
                var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
                var database = client.GetDatabase("airport");
                _canceledFlightsCollection = database.GetCollection<BsonDocument>(collectionName);
            }

            public List<T> GetCanceledFlightsData(Func<BsonDocument, T> transform)
            {
                try
                {
                    var documents = _canceledFlightsCollection.Find(new BsonDocument()).ToList();
                    return documents.Select(doc => transform(doc)).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                    return new List<T>();
                }
            }

            public T GetCanceledFlightById(string id, Func<BsonDocument, T> transform)
            {
                try
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
                    var document = _canceledFlightsCollection.Find(filter).FirstOrDefault();
                    return document != null ? transform(document) : default;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                    return default;
                }
            }

            public void InsertCanceledFlight(T data, Func<T, BsonDocument> transform)
            {
                try
                {
                    var document = transform(data);
                    _canceledFlightsCollection.InsertOne(document);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
                }
            }

            public void UpdateCanceledFlight(string id, T updatedData, Func<T, BsonDocument> transform)
            {
                try
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
                    var document = transform(updatedData);
                    _canceledFlightsCollection.ReplaceOne(filter, document);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при обновлении данных: {ex.Message}");
                }
            }

            public void DeleteCanceledFlight(string id)
            {
                try
                {
                    var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId(id));
                    _canceledFlightsCollection.DeleteOne(filter);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при удалении данных: {ex.Message}");
                }
            }
        }
    }
}