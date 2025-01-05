using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenuUI; // Le menu de pause
    public GameObject successUI;   // Le menu de succès
    private bool isPaused = false;

    void Update()
    {
        // Vérifie si le menu de succès n'est pas actif avant de permettre l'ouverture/fermeture du menu de pause
        if (!successUI.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);  // Désactive le menu de pause
        Time.timeScale = 1f;           // Reprend le temps
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);   // Active le menu de pause
        Time.timeScale = 0f;           // Met en pause le temps
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;           // Reprend le temps
        SceneManager.LoadScene("MainMenu"); // Charge la scène du menu principal
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();  // Quitte l'application
    }
}
