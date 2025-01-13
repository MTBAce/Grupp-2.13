using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject GameOver;

    public void KillPlayer(GameObject player)
    {
        // Inaktivera spelaren
        player.SetActive(false);

        FindObjectOfType<Score>().GameOver();

        GameOver.SetActive(true);

        Time.timeScale = 0f;


    }
}
