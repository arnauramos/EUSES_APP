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

    public Image CharacterEditorImage;
    public Image SettingsImage;
    public Image CreditsImage;

    private Color32 lightGreen = new Color32(207, 255, 191, 255);

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            updateButton(WorldsButton);
        }
        else
        {
            onCharacterEditorButtonClick();
        }
    }


    public void onWorldsButtonClick() {
        SceneManager.LoadScene(2);
        updateButton(WorldsButton);
    }
    public void onCharacterEditorButtonClick() {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(1);
        }
        updateButton(CharacterEditorButton);
        updateImage(CharacterEditorImage);
    }
    public void onSettingsButtonClick() {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(1);
        }
        updateButton(SettingsButton);
        updateImage(SettingsImage);
    }
    public void onCreditsButtonClick() {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(1);
        }
        updateButton(CreditsButton);
        updateImage(CreditsImage);
    }
    public void onLogoutButtonClick() {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(1);
        }
        updateButton(LogoutButton);
        SceneManager.LoadScene(0);
    }

    private void updateImage(Image img)
    {
        CharacterEditorImage.enabled = false;
        SettingsImage.enabled = false;
        CreditsImage.enabled = false;

        img.enabled = true;
    }

    private void updateButton(Button btn)
    {
        TurnWhite(WorldsButton);
        TurnWhite(CharacterEditorButton);
        TurnWhite(SettingsButton);
        TurnWhite(CreditsButton);
        TurnWhite(LogoutButton);

        TurnRed(btn);
    }

    private void TurnRed(Button button)
    {
        button.image.color = lightGreen;
    }

    private void TurnWhite(Button button)
    {
        button.image.color = Color.white;
    }

}
