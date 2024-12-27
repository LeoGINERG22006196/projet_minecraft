using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assurez-vous que "Big Vegas" a le tag "Player"
        {
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(coinValue);
            }
            Destroy(gameObject); // Faire disparaître la pièce
        }
    }
}
