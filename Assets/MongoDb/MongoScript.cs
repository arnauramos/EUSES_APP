﻿using System.Collections;
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
        insertUser("TestUser", "TestPassword");
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

    private void loginUser(User_Model user)
    {
        AppManager.Instance.currentUser = user;
        insertProfile();
    }

    public bool checkRegisterInfoDB(string _username, string _password)
    {
        Init();

        List<User_Model> Users = db.GetCollection<User_Model>("Users").Find(new BsonDocument()).ToList();

        foreach (User_Model user in Users)
        {
            if (_username == user.Username)
            {
                return false;
            }
        }
        insertUser(_username, _password);
        Shutdown();
        return true;
    }

    private void insertUser(string _username, string _password)
    {
        var usersCollection = db.GetCollection<User_Model>("Users");
        var auxUser = new User_Model();
        auxUser.Username = _username;
        auxUser.Password = _password;
        usersCollection.InsertOne(auxUser);

        Debug.Log("Usuario insertado");
    }

    public void insertProfile(string _profilename)
    {
        // INIT THE DB
        Init();

        // CREATE NEW PROFILE WITH _profilename AND INSERT INTO ITS COLLECTION
        var profilesCollection = db.GetCollection<Profile_Model>("Profiles");
        var auxProfile = new Profile_Model();
        auxProfile.ProfileName = _profilename;
        profilesCollection.InsertOne(auxProfile);

        // UPDATE USER'S PROFILES ARRAY WITH THE NEW PROFILE
        var usersCollection = db.GetCollection<User_Model>("Users");
        var update = Builders<User_Model>.Update.AddToSet("id_profile", auxProfile._id);
        var filter = Builders<User_Model>.Filter.Eq("_id", AppManager.Instance.currentUser._id);
        usersCollection.UpdateOne(filter, update);

        // SHUTDOWN THE DB
        Shutdown();
    }
}
