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


    void Start()
    {
      
    }

    public void KillPlayer()
    {      
        FindFirstObjectByType<Score>().GameOver();

        GameOver.SetActive(true);
               
        Time.timeScale = 0f;
    }
    public void EnemyKilled()
    {
        enemiesKilled++;
        if (enemiesKilled == 25)
        {
            enemySpawner.IncreaseDifficulty();
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

