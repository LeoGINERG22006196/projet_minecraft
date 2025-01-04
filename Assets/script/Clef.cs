using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public static bool isKeyCollected = false;
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
        if (other.CompareTag("Player"))
        {
            isKeyCollected = true;
            // Joue le son défini dans l'AudioSource
            if (audioSource != null)
            {
                audioSource.Play(); // Joue le son défini dans l'AudioSource
            }
            Debug.Log("Key collected!");
            Destroy(gameObject, 0.1f);
        }
    }
}
