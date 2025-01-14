using UnityEngine;
using UnityEngine.UI;
using Unity;
public class GameManager : MonoBehaviour
{
    public GameObject GameOver;

    public void KillPlayer(GameObject player)
    {
        // Inaktivera spelaren
        player.SetActive(false);

        FindFirstObjectByType<Score>().GameOver();

        GameOver.SetActive(true);

        Time.timeScale = 0f;


    }
}
