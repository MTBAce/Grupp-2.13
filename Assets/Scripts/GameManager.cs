using UnityEngine;
using UnityEngine.UI;
using Unity;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public GameObject GameOver;

    public void KillPlayer()
    {

        FindFirstObjectByType<Score>().GameOver();

        //GameOver.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);


    }
}
