using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MongoDB.Bson;

public class Profile_Model 
{
    public ObjectId _id;
    public string ProfileName { set; get; }

    public int Trophies { set; get; }
    public int Gender { set; get; }

    public int id_face { set; get; }
    public int id_hair { set; get; }
    public int id_camiseta { set; get; }
    public int id_pantalon { set; get; }
    public int id_bambas { set; get; }
    public int id_skin { set; get; }

    public int id_hair_boy_selected { set; get; }
    public int id_hair_girl_selected { set; get; }
}
