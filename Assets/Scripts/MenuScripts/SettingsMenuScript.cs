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
}
