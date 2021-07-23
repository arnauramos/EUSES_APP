using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelection : MonoBehaviour
{
    Vector3 targetRot;
    Vector3 currentAngle;
    public int currentSelection;
    public int totalWorlds = 7;
    public List<GameObject> planetas;

    private float smallScale = 3.8725f;
    private float bigScale = 10f;
    private float selectedScale = 13f;
    public WorldInfoScript wiScript;

    public Swipe swipeControls;

    private bool planetSelected = false;
    private bool planetEnterFinished = false;
    public bool planetExiting = false;
    public List<Vector3> planetOriginPositions;

    public GameObject worldPanel;

    void Start()
    {
        currentSelection = 1;
        updateScale();
        updateButtons();
        updatePlanetOriginPositions();
    }

    void Update()
    {
        if (planetSelected)
        {
            if (planetExiting)
            {
                ExitPlanet();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    planetExiting = true;
                }
                if (!planetEnterFinished)
                {
                    EnterPlanet();
                }
            }
            return;
        }
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
            updateButtons();
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
            updateButtons();
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
        if (planetSelected)
            return;

        wiScript.hideText();
        planetSelected = true;
    }
    private void updateButtons()
    {
        int i = 1;
        foreach (GameObject planeta in planetas)
        {
            if (i == currentSelection)
            {
                StartCoroutine(PlanetButtonActive(1.75f, planeta));
            }
            else
            {
                planeta.transform.Find("PlanetButton").gameObject.SetActive(false);
            }
            i++;
        }
    }

    IEnumerator PlanetButtonActive(float time, GameObject planeta)
    {
        yield return new WaitForSeconds(time);
        planeta.transform.Find("PlanetButton").gameObject.SetActive(true);
    }
    private void EnterPlanetMenu()
    {
        worldPanel.SetActive(true);
        gameObject.SetActive(false);
    }
    public void EnterPlanet()
    {
        GameObject planeta = planetas[currentSelection - 1];

        float scaleBig = Mathf.LerpAngle(planeta.transform.localScale.y, selectedScale, 1.0f * Time.deltaTime);
        planeta.transform.localScale = new Vector3(scaleBig, scaleBig, scaleBig);

        Vector3 p_dest = planeta.transform.localPosition;

        foreach (GameObject planet in planetas)
        {
            float posX = Mathf.Lerp(planet.transform.localPosition.x, p_dest.x, 1.0f * Time.deltaTime);
            float posY = Mathf.Lerp(planet.transform.localPosition.y, p_dest.y, 1.0f * Time.deltaTime);
            float posZ = Mathf.Lerp(planet.transform.localPosition.z, p_dest.z, 1.0f * Time.deltaTime);
            planet.transform.localPosition = new Vector3(posX, posY, posZ);
        }


        if (planeta.transform.localScale.y > 12f)
        {
            planetEnterFinished = true;
            EnterPlanetMenu();
        }

    }
    public void ExitPlanet()
    {
        planetEnterFinished = false;

        GameObject planeta = planetas[currentSelection - 1];

        float scaleBig = Mathf.LerpAngle(planeta.transform.localScale.y, 6.6f, 2.0f * Time.deltaTime);
        planeta.transform.localScale = new Vector3(scaleBig, scaleBig, scaleBig);

        for (int i = 0; i < planetas.Count; i++)
        {
            GameObject p = planetas[i];
            Vector3 p_pos = planetOriginPositions[i];
            float pX = Mathf.Lerp(p.transform.localPosition.x, p_pos.x, 2.0f * Time.deltaTime);
            float pY = Mathf.Lerp(p.transform.localPosition.y, p_pos.y, 2.0f * Time.deltaTime);
            float pZ = Mathf.Lerp(p.transform.localPosition.z, p_pos.z, 2.0f * Time.deltaTime);
            p.transform.localPosition = new Vector3(pX, pY, pZ);
        }

        if (planeta.transform.localScale.x < 6.8f)
        {
            wiScript.ShowCurrentInfo();
            planetSelected = false;
            planetExiting = false;
        }
    }

    private void updatePlanetOriginPositions()
    {
        for (int i = 0; i < planetas.Count; i++)
        {
            if (planetOriginPositions.Count < planetas.Count)
            {
                planetOriginPositions.Add(planetas[i].transform.localPosition);
            }
            else
            {
                planetOriginPositions[i] = planetas[i].transform.localPosition;
            }
        }
    }
}
