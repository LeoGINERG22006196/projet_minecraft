using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGold : MonoBehaviour
{
    // Vitesses de rotation pour chaque axe en degrés par seconde
    public float rotationSpeedX = 0f;
    public float rotationSpeedY = 0f;
    public float rotationSpeedZ = 100f;

    void Update()
    {
        // Appliquer la rotation sur les axes X, Y et Z
        transform.Rotate(rotationSpeedX * Time.deltaTime, rotationSpeedY * Time.deltaTime, rotationSpeedZ * Time.deltaTime);
    }
}
