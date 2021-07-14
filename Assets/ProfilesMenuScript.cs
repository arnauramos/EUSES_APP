using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class ProfilesMenuScript : MonoBehaviour
{
    public TMP_InputField profilename;

    public void goToCreateProfile()
    {
        SceneManager.LoadScene(7);
    }
    public void onCreateProfile()
    {
        if (profilename.text.Length >= 3)
        {
            if (MongoScript.Instance.insertProfile(profilename.text))
            {
                SceneManager.LoadScene(6);
            }
            else
            {
                Debug.Log("El nombre de perfil ya está en uso");
            }
        }
        else
        {
            Debug.Log("Nombre de perfil no válido");
        }
    }
    public void onCancelCreation()
    {
        SceneManager.LoadScene(6);
    }
    public void onSelectProfileClick(string _id)
    {
        //MongoScript.Instance.selectProfile(_id);
    }
}
