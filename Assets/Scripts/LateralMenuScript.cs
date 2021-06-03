using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LateralMenuScript : MonoBehaviour
{
    public Button WorldsButton;
    public Button CharacterEditorButton;
    public Button SettingsButton;
    public Button CreditsButton;
    public Button LogoutButton;

    private void Start()
    {

    }


    public void onWorldsButtonClick() {
        SceneManager.LoadScene(3);
    }
    public void onCharacterEditorButtonClick() {
        SceneManager.LoadScene(5);
    }
    public void onSettingsButtonClick() {
        SceneManager.LoadScene(4);
    }
    public void onCreditsButtonClick() {

    }
    public void onLogoutButtonClick() {

    }

}
