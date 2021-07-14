using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MongoDB.Bson;

public class User_Model 
{
    public ObjectId _id;

    public string Username { set; get; }
    public string Password { set; get; }

    public ObjectId[] id_profile { set; get; }
}
