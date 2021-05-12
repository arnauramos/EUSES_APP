using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelection : MonoBehaviour
{
    Vector3 targetRot;
    Vector3 currentAngle;
    public int currentSelection;
    public int totalWorlds = 7;
    public List<GameObject> planetas;

    public float smallScale = 3.8725f;
    public float bigScale = 10f;
    public WorldInfoScript wiScript;

    public Swipe swipeControls;

    void Start()
    {
        currentSelection = 1;
        updateScale();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || swipeControls.swipeRight) // Tiene que restar
        {
            if(currentSelection == 1)
            {
                currentSelection = 8;
            }
            currentAngle = transform.eulerAngles;
            targetRot = targetRot + new Vector3(0, -51.42f, 0);
            currentSelection--;
            wiScript.ExitCurrentInfo(currentSelection);
        }

        if (Input.GetKeyDown(KeyCode.A) || swipeControls.swipeLeft) // Tiene que sumar
        {
            if(currentSelection == 7)
            {
                currentSelection = 0;
            }
            currentAngle = transform.eulerAngles;
            targetRot = targetRot + new Vector3(0, 51.42f, 0);
            currentSelection++;
            wiScript.ExitCurrentInfo(currentSelection);
        }

        currentAngle = new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetRot.y, 2.0f * Time.deltaTime), 0);
        transform.eulerAngles = currentAngle;
        updateScale();
    }
    private void updateScale()
    {
        int i = 1;
        foreach (GameObject planeta in planetas)
        {
            float scaleSmall = Mathf.LerpAngle(planeta.transform.localScale.y, smallScale, 2.0f * Time.deltaTime);
            planeta.transform.localScale = new Vector3(scaleSmall, scaleSmall, scaleSmall);

            if (i == currentSelection)
            {
                float scaleBig = Mathf.LerpAngle(planeta.transform.localScale.y, bigScale, 2.0f * Time.deltaTime);
                planeta.transform.localScale = new Vector3(scaleBig, scaleBig, scaleBig);
            }
            i++;
        }
    }
    public void planetPressed()
    {
        Debug.Log("Pressed");
    }
}
