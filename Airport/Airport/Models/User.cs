using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class User : INotifyPropertyChanged
{
    private ObjectId _id;
    private string _login;
    private string _password;
    private string _accessRight;

    [BsonId]
    public ObjectId Id
    {
        get => _id;
        set
        {
            if (_id != value)
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    [BsonElement("login")]
    public string Login
    {
        get => _login;
        set
        {
            if (_login != value)
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
    }

    [BsonElement("password")]
    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
    }

    [BsonElement("accessRight")]
    public string AccessRight
    {
        get => _accessRight;
        set
        {
            if (_accessRight != value)
            {
                _accessRight = value;
                OnPropertyChanged(nameof(AccessRight));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

