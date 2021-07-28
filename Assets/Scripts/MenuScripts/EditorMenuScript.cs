using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EditorMenuScript : MonoBehaviour
{
    [System.Serializable]
    public class serializableClass
    {
        public List<Material> Materials;
    }

    public List<GameObject> Botones;
    public List<GameObject> Inventarios;
    public List<GameObject> ColorPickers;
    public List<GameObject> Genders;

    public GameObject InvPeloGirl;
    public GameObject InvPeloBoy;

    public List<Material> MSkin;
    public List<serializableClass> MPeloGirl = new List<serializableClass>();
    public List<serializableClass> MPeloBoy = new List<serializableClass>();
    public List<Material> MCamiseta;
    public List<Material> MPantalon;
    public List<Material> MBambas;
    public List<Material> MOjos;

    public GameObject Skin;
    public GameObject Camiseta;
    public GameObject Pantalones;
    public GameObject Ojos;
    public List<GameObject> LBambas;
    public List<GameObject> LPeloGirl;
    public GameObject peloGirl5flipped;
    public List<GameObject> LPeloBoy;


    private Color selectedColor = new Color32(117, 255, 232, 255);

    void Start()
    {
        updateInventarios(Botones[0]);
        updateColorPiel(ColorPickers[0]);
        updateGender(Genders[0]);
        updateMaterials();
    }

    public void onButtonClicked(GameObject self)
    {
        updateInventarios(self);
    }

    public void onColorClicked(GameObject self)
    {
        updateColorPiel(self);
    }

    public void onGenderClicked(GameObject self)
    {
        updateGender(self);
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

    private void updateGender(GameObject currentGender)
    {
        int i = 0;
        foreach (GameObject gnd in Genders)
        {
            if (gnd == currentGender)
            {
                gnd.transform.Find("Outline").gameObject.SetActive(true);
            }
            else
            {
                gnd.transform.Find("Outline").gameObject.SetActive(false);
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
        updateMaterials();
    }
    public void onEditCamiseta(int id)
    {
        AppManager.Instance.currentProfile.id_camiseta = id;
        updateMaterials();
    }
    public void onEditPantalones(int id)
    {
        AppManager.Instance.currentProfile.id_pantalon = id;
        updateMaterials();
    }
    public void onEditBambas(int id)
    {
        AppManager.Instance.currentProfile.id_bambas = id;
        updateMaterials();
    }
    public void onEditSkinColor(int id)
    {
        AppManager.Instance.currentProfile.id_skin = id;
        updateMaterials();
    }
    public void onEditGender(int id)
    {
        AppManager.Instance.currentProfile.Gender = id;
        updateMaterials();
    }

    private void updateMaterials()
    {
        // UPDATE SKIN
        Skin.GetComponent<SkinnedMeshRenderer>().material = MSkin[AppManager.Instance.currentProfile.id_skin];

        // UPDATE CAMISETA
        Camiseta.GetComponent<SkinnedMeshRenderer>().material = MCamiseta[AppManager.Instance.currentProfile.id_camiseta];

        // UPDATE PANTALONES
        Pantalones.GetComponent<SkinnedMeshRenderer>().material = MPantalon[AppManager.Instance.currentProfile.id_pantalon];

        // UPDATE OJOS
        //Ojos.GetComponent<SkinnedMeshRenderer>().materials[0] = MSkin[AppManager.Instance.currentProfile.id_eyes];

        // UPDATE BAMBAS
        foreach (var bamba in LBambas)
        {
            bamba.GetComponent<SkinnedMeshRenderer>().material = MBambas[AppManager.Instance.currentProfile.id_bambas];
        }

        // UPDATE GENDER
        updateGender();

        // UPDATE PELO GIRL
        int p_g = 0;
        foreach (var peloG in LPeloGirl)
        {
            peloG.GetComponent<SkinnedMeshRenderer>().material = MPeloGirl[p_g].Materials[AppManager.Instance.currentProfile.id_hair];
            if (p_g == 4)
            {
                peloGirl5flipped.GetComponent<SkinnedMeshRenderer>().material = MPeloGirl[p_g].Materials[AppManager.Instance.currentProfile.id_hair];
            }
            p_g++;
        }

        // UPDATE PELO BOY
        int p_b = 0;
        foreach (var peloB in LPeloBoy)
        {
            peloB.GetComponent<SkinnedMeshRenderer>().material = MPeloBoy[p_b].Materials[AppManager.Instance.currentProfile.id_hair];
            p_b++;
        }
    }

    private void updateGender()
    {
        int gender = AppManager.Instance.currentProfile.Gender;
        int indexHair = 0;

        /** male **/
        if (gender == 0)
        {
            foreach (var g_h in LPeloGirl)
            {
                g_h.SetActive(false);
            }
            foreach (var b_h in LPeloBoy)
            {
                if (AppManager.Instance.currentProfile.id_hair_boy_selected == indexHair)
                {
                    b_h.SetActive(true);
                }
                else
                {
                    b_h.SetActive(false);
                }
                indexHair++;
            }
            InvPeloBoy.SetActive(true);
            InvPeloGirl.SetActive(false);
        }

        /** female **/
        else if (gender == 1)
        {
            foreach (var b_h in LPeloBoy)
            {
                b_h.SetActive(false);
            }
            foreach (var g_h in LPeloGirl)
            {
                if (AppManager.Instance.currentProfile.id_hair_girl_selected == indexHair)
                {
                    g_h.SetActive(true);
                    if (indexHair == 4)
                    {
                        peloGirl5flipped.SetActive(true);
                    }
                    else
                    {
                        peloGirl5flipped.SetActive(false);
                    }
                }
                else
                {
                    g_h.SetActive(false);
                }
                indexHair++;
            }
            InvPeloGirl.SetActive(true);
            InvPeloBoy.SetActive(false);
        }
    }

    public void onChangeBoyHair(int id)
    {
        AppManager.Instance.currentProfile.id_hair_boy_selected = id;
        updateMaterials();
    }
    public void onChangeGirlHair(int id)
    {
        AppManager.Instance.currentProfile.id_hair_girl_selected = id;
        updateMaterials();
    }
}
