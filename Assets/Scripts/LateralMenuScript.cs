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

    public Image WorldsImage;
    public Image CharacterEditorImage;
    public Image SettingsImage;
    public Image CreditsImage;

    private Color32 lightGreen = new Color32(207, 255, 191, 255);

    private void Start()
    {
        onWorldsButtonClick();
    }


    public void onWorldsButtonClick() {
        updateButton(WorldsButton);
        updateImage(WorldsImage);
    }
    public void onCharacterEditorButtonClick() {
        updateButton(CharacterEditorButton);
        updateImage(CharacterEditorImage);
    }
    public void onSettingsButtonClick() {
        updateButton(SettingsButton);
        updateImage(SettingsImage);
    }
    public void onCreditsButtonClick() {
        updateButton(CreditsButton);
        updateImage(CreditsImage);
    }
    public void onLogoutButtonClick() {
        updateButton(LogoutButton);
        SceneManager.LoadScene(0);
    }

    private void updateImage(Image img)
    {
        WorldsImage.enabled = false;
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
