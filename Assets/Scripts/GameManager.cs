using UnityEngine;
using UnityEngine.UI;
using Unity;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    //public GameObject GameOver;
    public int enemiesKilled;
    public EnemySpawner enemySpawner;

    public void KillPlayer()
    {

        FindFirstObjectByType<Score>().GameOver();

        //GameOver.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
}
