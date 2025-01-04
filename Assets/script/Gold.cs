using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 10;
    private AudioSource audioSource;


    public Transform chestUp; // Référence à l'élément "chest_Up"
    public float animationDuration = 1.0f; // Durée de l'animation

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
        if (other.CompareTag("Player")) // Assurez-vous que "Player" est bien le tag du joueur
        {
            // Trouver le ScoreManager et ajouter des points
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

            // Détruire l'objet après un léger délai pour laisser le son se jouer
            Destroy(gameObject, 0.1f);
        }
    }
}