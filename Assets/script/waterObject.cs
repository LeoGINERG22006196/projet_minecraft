using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterObject : MonoBehaviour
{
    public GameObject loseUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assurez-vous que "Big Vegas" a le tag "Player"
        {
            loseUI.SetActive(true);
        }
    }
}
