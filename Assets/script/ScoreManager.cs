using TMPro; // Ajoutez cette ligne pour utiliser TextMeshPro
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Utilisez TMP_Text au lieu de Text
    private int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
