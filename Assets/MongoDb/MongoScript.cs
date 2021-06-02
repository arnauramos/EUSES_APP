using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MongoDB.Driver;
using MongoDB.Bson;



public class MongoScript : MonoBehaviour
{
    private const string MONGO_URI = "mongodb+srv://EusesAPP:EusesAPP@cluster0.15ctn.mongodb.net/EusesDB?retryWrites=true&w=majority";
    private const string DATABASE_NAME = "EusesDB";
    private MongoClient client;
    private IMongoDatabase db;

    private void Start()
    {
        client = new MongoClient(MONGO_URI);
        db = client.GetDatabase(DATABASE_NAME);

        insertTestUser();

    }

    private void insertTestUser()
    {
        var usersCollection = db.GetCollection<BsonDocument>("Users");
        var testUser = new BsonDocument { { "Name", "UsuarioTest" }, { "Password", "ContraseñaTest" } };
        usersCollection.InsertOne(testUser);

        Debug.Log("Usuario insertado");
    }
}
