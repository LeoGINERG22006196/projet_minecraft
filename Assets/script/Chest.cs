using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    private bool isOpened = false;
    public int coinValue = 100;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpened)
        {
            if (KeyPickup.isKeyCollected)
            {
                isOpened = true;
                Debug.Log("Chest opened!");
                // Ajouter ici l'animation ou effet d'ouverture
                ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
                if (scoreManager != null)
                {
                    scoreManager.AddScore(coinValue);
                }
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("You need the key to open the chest!");
            }
        }
    }
}
