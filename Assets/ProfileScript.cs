using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ProfileScript : MonoBehaviour
{
    public TextMeshProUGUI ProfileName;
    public TextMeshProUGUI Trophies;

    private Profile_Model profile;

    public void initProfile (Profile_Model _profile)
    {
        profile = _profile;

        ProfileName.text = profile.ProfileName;
        Trophies.text = profile.Trophies.ToString();

        GetComponent<Button>().onClick.AddListener(selectProfile);

    }

    private void selectProfile()
    {
        AppManager.Instance.currentProfile = profile;

        Debug.Log(AppManager.Instance.currentProfile.ProfileName);
        SceneManager.LoadScene(3);
    }
}
