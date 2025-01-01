using UnityEngine;

public class GoldCupCollector : MonoBehaviour
{
    public GameObject successUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            successUI.SetActive(true); 
            Time.timeScale = 0f;
        }
    }
}
