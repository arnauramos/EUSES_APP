using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldInfoScript : MonoBehaviour
{
    public List<string> WorldNames;
    public List<GameObject> Planetas;
    private int currentSelection = 1;

    public TextMeshProUGUI WorldName;

    private void Start()
    {
        ShowCurrentInfo();
    }

    public void hideText(){
        WorldName.CrossFadeAlpha(0f, 1f, false);
    }

    public void ExitCurrentInfo(int _currentSelection) {
        hideText();
        currentSelection = _currentSelection;
        StartCoroutine(ShowInfoCoroutine(1f));
    }
    public void ShowCurrentInfo() {

        //WorldName.text = WorldNames[currentSelection - 1];
        WorldName.text = Planetas[currentSelection - 1].name;
        WorldName.color = Planetas[currentSelection - 1].GetComponent<MeshRenderer>().material.color;

        WorldName.CrossFadeAlpha(1f, 1f, false);
    }
    IEnumerator ShowInfoCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        ShowCurrentInfo();
    }
}
