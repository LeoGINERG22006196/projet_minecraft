using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject[] hearts; // Les images des cœurs
    public GameObject loseUI;   // L'écran de défaite
    private int health = 3;     // Vie initiale du personnage

    // Méthode pour réduire la vie
    public void TakeDamage()
    {
        if (health > 0)
        {
            health--; // Réduit la vie
            hearts[health].SetActive(false); // Cache un cœur

            if (health == 0)
            {
                LoseGame(); // Affiche l'écran de défaite
            }
        }
    }

    private void LoseGame()
    {
        loseUI.SetActive(true); // Affiche la LoseUI
        // Vous pouvez ajouter d'autres actions ici (arrêter le jeu, etc.)
    }
}
