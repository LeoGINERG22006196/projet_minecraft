using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGold : MonoBehaviour
{
    // Vitesse de rotation en degrés par seconde
    public float rotationSpeed = 100f;

    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}
