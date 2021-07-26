using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private Vector3 lastPos, currPos;
    private float rotationSpeed = -0.2f;

    void Start()
    {
        lastPos = Input.mousePosition;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            currPos = Input.mousePosition;
            Vector3 offset = currPos - lastPos;
            transform.RotateAround(transform.position, Vector3.up, offset.x * rotationSpeed);
        }
        lastPos = Input.mousePosition;

        if (Input.touches.Length > 0)
        {
            currPos = Input.touches[0].position;
            Vector3 offset = currPos - lastPos;
            transform.RotateAround(transform.position, Vector3.up, offset.x * rotationSpeed);
            lastPos = Input.touches[0].position;
        }
    }
}
