using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginMenuScript : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;

    private void Start()
    {
    }

    public void onLoginButtonClick()
    {
        int checkLoginInfo_Res = checkLoginInfo();
        if (checkLoginInfo_Res == 0)
        {
            if (MongoScript.Instance.checkLoginInfoDB(username.text, password.text))
            {
                SceneManager.LoadScene(6);
            }
            else
            {
                Debug.Log("Contraseña o nombre de usuario incorrecto");
            }
        }
        else if (checkLoginInfo_Res == 1)
        {
            Debug.Log("Nombre de usuario no válido");
        }
        else if (checkLoginInfo_Res == 2)
        {
            Debug.Log("Contraseña no válida");
        }
    }

    private int checkLoginInfo()
    {
        if (username.text.Length < 5)
        {
            return 1;
        }
        else if (password.text.Length < 5)
        {
            return 2;
        }
        return 0;
    }

    public void toRegister()
    {
        SceneManager.LoadScene(2);
    }
}
