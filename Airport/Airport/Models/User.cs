using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User
{
    [BsonId]
    public ObjectId Id { get; set; }
    [BsonElement("login")]
    public string Login { get; set; }
    [BsonElement("password")]
    public string Password { get; set; }
    [BsonElement("accessRight")]
    public string AccessRight { get; set; }  
}

