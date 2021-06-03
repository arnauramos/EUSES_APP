using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    public static AppManager Instance { get; private set; }

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

    public User_Model currentUser;
}
