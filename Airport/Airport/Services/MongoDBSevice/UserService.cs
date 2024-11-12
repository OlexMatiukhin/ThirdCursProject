using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Airport.Services.MongoDBService
{
    public class UserService
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _userCollection = database.GetCollection<User>("users");
        }


        public void AddUser(User user)
        {
            try
            {
                
                var existingUser = _userCollection.Find(u => u.Login == user.Login).FirstOrDefault();
                if (existingUser != null)
                {
                    Console.WriteLine("Користувач з таким логіном вже існує.");
                    return;
                }

      
                _userCollection.InsertOne(user);
                Console.WriteLine("Користувач доданий успішно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при додаванні користувача: {ex.Message}");
            }
        }

     
        public void UpdateUser(User user)
        {
            if (user.AccessRight != "власник")
            {
                try
                {
                    var existingUser = _userCollection.Find(u => u.Login == user.Login).FirstOrDefault();
                    if (existingUser == null)
                    {
                        Console.WriteLine("Користувач з таким логіном не знайдений.");
                        return;
                    }

                   
                    var updateDefinition = Builders<User>.Update
                        .Set(u => u.Password, user.Password)
                        .Set(u => u.AccessRight, user.AccessRight);

                    _userCollection.UpdateOne(u => u.Login == user.Login, updateDefinition);
                    Console.WriteLine("Користувач оновлений успішно.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при оновленні користувача: {ex.Message}");
                }
            }
        }

   
        public void DeleteUser(User user)
        {
            if (user.AccessRight != "власник")
            {
                try
                {
                    var deleteResult = _userCollection.DeleteOne(u => u.Login == user.Login);
                    if (deleteResult.DeletedCount > 0)
                    {
                        Console.WriteLine("Користувач видалений успішно.");
                    }
                    else
                    {
                        Console.WriteLine("Користувач з таким логіном не знайдений.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при видаленні користувача: {ex.Message}");
                }
            }
        }

        public User GetUserByLogin(string login)
        {
            try
            {
             
                var user = _userCollection.Find(u => u.Login == login).FirstOrDefault();
                return user; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching user by login: {ex.Message}");
                return null; 
            }
        }
        public List<User> GetUsers()
        {
            try
            {
               
                return _userCollection.Find(user => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching users: {ex.Message}");
                return new List<User>(); 
            }
        }
    }
}

