using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public static bool isKeyCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isKeyCollected = true;
            Debug.Log("Key collected!");
            Destroy(gameObject);
        }
    }
}
