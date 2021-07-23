using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMenuScript : MonoBehaviour
{
    private bool fade = false;
    private bool fOut = false;
    private Image background;

    public WorldSelection worldSelectionScript;

    private void OnEnable()
    {
        fade = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            var auxColor = background.color;

            auxColor.a += 2*Time.deltaTime;
            if (auxColor.a >= 1)
            {
                auxColor.a = 1;
                fade = false;
            }

            background.color = auxColor;
        }
        if (fOut)
        {
            fadeOut();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            fOut = true;
            worldSelectionScript.gameObject.SetActive(true);
            worldSelectionScript.planetExiting = true;
        }
    }

    private void fadeOut()
    {
        var auxC = background.color;

        auxC.a -= 2 * Time.deltaTime;
        if (auxC.a <= 0.02f)
        {
            auxC.a = 0.02f;
            fOut = false;
            fade = false;
            gameObject.SetActive(false);
        }

        background.color = auxC;
    }
}
