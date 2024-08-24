using Airport.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


public class BaggageService
{
    private readonly IMongoCollection<Baggage> _baggageCollection;

    public BaggageService()
    {
        // Подключение к MongoDB
        
        var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
        var database = client.GetDatabase("airport");
        _baggageCollection = database.GetCollection<Baggage>("baggage");
    }

    public List<Baggage> GetBaggageData()
    {
        try
        {
            return _baggageCollection.Find(b => true).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
            return new List<Baggage>();
        }
    }
}