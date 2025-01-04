using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    private bool isOpened = false;
    public int coinValue = 100;
    private AudioSource audioSource;

    private void Start()
    {
        // Ajoute ou récupère l'AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }
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

                // Joue le son défini dans l'AudioSource
                if (audioSource != null)
                {
                    audioSource.Play(); // Joue le son défini dans l'AudioSource
                }
                Destroy(gameObject, 0.1f);
            }
            else
            {
                Debug.Log("You need the key to open the chest!");
            }
        }
    }
}
