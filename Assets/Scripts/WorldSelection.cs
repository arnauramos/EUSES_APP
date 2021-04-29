using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSelection : MonoBehaviour
{
    Vector3 targetRot;
    Vector3 currentAngle;
    public int currentSelection;
    public int totalWorlds = 7;

    void Start()
    {
        currentSelection = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) // Tiene que restar
        {
            if(currentSelection == 1)
            {
                currentSelection = 8;
            }
            currentAngle = transform.eulerAngles;
            targetRot = targetRot + new Vector3(0, -51.42f, 0);
            currentSelection--;
        }

        if (Input.GetKeyDown(KeyCode.A)) // Tiene que sumar
        {
            if(currentSelection == 7)
            {
                currentSelection = 0;
            }
            currentAngle = transform.eulerAngles;
            targetRot = targetRot + new Vector3(0, 51.42f, 0);
            currentSelection++;
        }

        currentAngle = new Vector3(0, Mathf.LerpAngle(currentAngle.y, targetRot.y, 2.0f * Time.deltaTime), 0);
        transform.eulerAngles = currentAngle;
    }
}
