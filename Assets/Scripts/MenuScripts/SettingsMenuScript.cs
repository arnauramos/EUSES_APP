using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuScript : MonoBehaviour
{
    public void onBackClicked()
    {
        SceneManager.LoadScene(3);
    }
    public void onLogOutClicked()
    {
        AppManager.Instance.currentUser = new User_Model();
        AppManager.Instance.currentProfile = new Profile_Model();

        SceneManager.LoadScene(1);
    }
}
