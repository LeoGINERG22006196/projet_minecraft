using System.Collections;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    private bool isOpened = false;
    public int coinValue = 100;
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
        if (other.CompareTag("Player") && !isOpened)
        {
            if (KeyPickup.isKeyCollected)
            {
                isOpened = true;
                Debug.Log("Chest opened!");


                // Jouer l'animation d'ouverture
                StartCoroutine(OpenChestAnimation());

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
            }
            else
            {
                Debug.Log("You need the key to open the chest!");
            }
        }
    }

    private IEnumerator OpenChestAnimation()
    {
        if (chestUp == null)
        {
            Debug.LogError("chestUp Transform is not assigned!");
            yield break;
        }

        Quaternion initialRotation = chestUp.localRotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

        float elapsedTime = 0;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            chestUp.localRotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / animationDuration);
            yield return null;
        }

        // Assurez-vous que la rotation finale est exactement celle cible
        chestUp.localRotation = targetRotation;
    }
}
