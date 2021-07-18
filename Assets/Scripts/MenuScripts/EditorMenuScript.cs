using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EditorMenuScript : MonoBehaviour
{

    public List<GameObject> Botones;
    public List<GameObject> Inventarios;
    public List<GameObject> ColorPickers;

    private Color selectedColor = new Color32(117, 255, 232, 255);

    void Start()
    {
        updateInventarios(Botones[0]);
        updateColorPiel(ColorPickers[0]);
    }

    public void onButtonClicked(GameObject self)
    {
        updateInventarios(self);
    }

    public void onColorClicked(GameObject self)
    {
        updateColorPiel(self);
    }

    private void updateInventarios(GameObject currentButton)
    {
        int i = 0;
        foreach (GameObject btn in Botones)
        {
            if (btn == currentButton)
            {
                Inventarios[i].SetActive(true);
                Botones[i].GetComponent<Image>().color = selectedColor;
            }
            else
            {
                Inventarios[i].SetActive(false);
                Botones[i].GetComponent<Image>().color = Color.white;
            }
            i++;
        }
    }

    private void updateColorPiel(GameObject currentColor)
    {
        int i = 0;
        foreach (GameObject clr in ColorPickers)
        {
            Debug.Log(clr);
            if (clr == currentColor)
            {
                clr.transform.Find("Outline").gameObject.SetActive(true);
            }
            else
            {
                clr.transform.Find("Outline").gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void onBackClicked()
    {
        // GUARDAR
        MongoScript.Instance.updateProfile();

        // SALIR DEL MENÚ DE EDICIÓN
        SceneManager.LoadScene(3);
    }

    public void onEditHair(int id)
    {
        AppManager.Instance.currentProfile.id_hair = id;
    }
    public void onEditCamiseta(int id)
    {
        AppManager.Instance.currentProfile.id_camiseta = id;
    }
    public void onEditPantalones(int id)
    {
        AppManager.Instance.currentProfile.id_pantalon = id;
    }
    public void onEditBambas(int id)
    {
        AppManager.Instance.currentProfile.id_bambas = id;
    }
    public void onEditSkinColor(int id)
    {
        AppManager.Instance.currentProfile.id_skin = id;
    }
}
