using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldsMenuScript : MonoBehaviour
{
    public GameObject ProfileGO;

    private void Start()
    {
        GameObject auxProfile = Instantiate(ProfileGO, gameObject.transform);
        auxProfile.GetComponent<ProfileScript>().initProfile(AppManager.Instance.currentProfile, true);
    }

    public void onSettingsButtonClick() {
        SceneManager.LoadScene(4);
    }
}
