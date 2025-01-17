using UnityEngine;
using UnityEngine.UI;
using Unity;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public GameObject GameOver;
    public int enemiesKilled;
    public EnemySpawner enemySpawner;
    public PowerupManager powerupManager;
    public float nextPowerup = 50;

    public bool arUnlocked = false;
    public bool shotgunUnlocked = false;
    public bool machinegunUnlocked = false;

    public TMP_Text killCount;

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
        UnlockWeapons();
        killCount.text = "Kills:" + enemiesKilled;
        if (enemiesKilled == nextPowerup)
        {
            enemySpawner.IncreaseDifficulty();
            powerupManager.ShowPowerupChoices();
            nextPowerup += 50;
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

    public void UnlockWeapons()
    {
        if (enemiesKilled == 50)
        {
            arUnlocked = true;
        }
        if (enemiesKilled == 150)
        {
            shotgunUnlocked = true;
        }
        if (enemiesKilled == 300)
        {
            machinegunUnlocked = true;
        }
    }

}

