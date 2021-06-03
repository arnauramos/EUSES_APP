using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MongoDB.Driver;
using MongoDB.Bson;



public class MongoScript : MonoBehaviour
{

    public static MongoScript Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    private const string MONGO_URI = "mongodb+srv://EusesAPP:EusesAPP@cluster0.15ctn.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";
    private const string DATABASE_NAME = "EusesDB";
    private MongoClient client;
    private IMongoDatabase db;

    private void Init()
    {
        client = new MongoClient(MONGO_URI);
        db = client.GetDatabase(DATABASE_NAME);
    }

    private void Shutdown()
    {
        client = null;
        db = null;
    }


    public void insertTestUser()
    {
        var usersCollection = db.GetCollection<User_Model>("Users");
        var testUser = new User_Model();
        testUser.Username = "TestUser";
        testUser.Password = "TestPassword";
        usersCollection.InsertOne(testUser);

        Debug.Log("Usuario insertado");
    }

    public bool checkLoginInfoDB(string _username, string _password)
    {
        Init();

        List<User_Model> Users = db.GetCollection<User_Model>("Users").Find(new BsonDocument()).ToList();

        foreach (User_Model user in Users)
        {
            if (_username == user.Username)
            {
                if (_password == user.Password)
                {
                    Shutdown();
                    loginUser(user);
                    return true;
                }
            }
        }
        Shutdown();
        return false;
    }

    public void loginUser(User_Model user)
    {
        AppManager.Instance.currentUser = user;
    }
}
