using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginMenuScript : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;

    public void onLoginButtonClick()
    {
        SceneManager.LoadScene(1);
        Debug.Log(password.text.ToString());
    }
}
