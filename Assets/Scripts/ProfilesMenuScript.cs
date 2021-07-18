using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ProfilesMenuScript : MonoBehaviour
{
    public TMP_InputField profilename;
    public GameObject grid;

    public GameObject ProfileGO;
    public GameObject CreateProfileGO;


    private void Start()
    {
        if (!grid) return;

        List<Profile_Model> userProfiles = MongoScript.Instance.getUserProfiles();
        for (int i = 0; i < userProfiles.Count; i++)
        {
            GameObject auxProfile = Instantiate(ProfileGO, grid.transform);
            auxProfile.GetComponent<ProfileScript>().initProfile(userProfiles[i], false);
        }

        GameObject auxCreateProfile = Instantiate(CreateProfileGO, grid.transform);
        auxCreateProfile.GetComponent<Button>().onClick.AddListener(goToCreateProfile);
    }


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
}
