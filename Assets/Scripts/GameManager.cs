using UnityEngine;
using UnityEngine.UI;
using Unity;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public GameObject GameOver;
    public int enemiesKilled;
    public EnemySpawner enemySpawner;
    public PowerupManager powerupManager;


    void Start()
    {
      
    }

    public void KillPlayer()
    {      
        FindFirstObjectByType<Score>().GameOver();

        GameOver.SetActive(true);
        Cursor.visible = true;

        Cursor.lockState = CursorLockMode.None; // Eller CursorLockMode.Locked

        Time.timeScale = .2f;
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled == 30)
        {
            enemySpawner.IncreaseDifficulty();
            powerupManager.ShowPowerupChoices();
            enemiesKilled = 0;
        }

    }
    public void RestartGame()
    {
        Time.timeScale = 1f; //Startar om spelet
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }
}

