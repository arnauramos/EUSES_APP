using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RegisterMenuScript : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;

    private void Start()
    {
    }

    public void onRegisterButtonClick()
    {
        int checkRegisterInfo_Res = checkRegisterInfo();
        if (checkRegisterInfo_Res == 0)
        {
            if (MongoScript.Instance.checkRegisterInfoDB(username.text, password.text))
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("El nombre de usuario ya está en uso");
            }
        }
        else if (checkRegisterInfo_Res == 1)
        {
            Debug.Log("Nombre de usuario no válido");
        }
        else if (checkRegisterInfo_Res == 2)
        {
            Debug.Log("Contraseña no válida");
        }
    }

    private int checkRegisterInfo()
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

    public void toLogin()
    {
        SceneManager.LoadScene(1);
    }
}
