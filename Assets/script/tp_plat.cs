using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp_plat : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assurez-vous que "Big Vegas" a le tag "Player"
        {
            other.transform.position = new Vector3(17, 1, 6);
            UnityEngine.Debug.Log("I TP");
        }
    }
}
