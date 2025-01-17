using UnityEngine;
using UnityEngine.UI;
using Unity;
using UnityEngine.SceneManagement;
using TMPro;
using System.Security.Cryptography;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject GameOver;
    public int enemiesKilled;
    public EnemySpawner enemySpawner;
    public PowerupManager powerupManager;
    public float nextPowerup = 3;

    public bool arUnlocked = false;
    public bool shotgunUnlocked = false;
    public bool machinegunUnlocked = false;
    public GameObject weaponUnlockText;

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
        if (enemiesKilled == 25 && !arUnlocked)
        {
            arUnlocked = true;
            ShowWeaponUnlockMessage("AR Unlocked!");
        }
        if (enemiesKilled == 50 && !shotgunUnlocked)
        {
            shotgunUnlocked = true;
            ShowWeaponUnlockMessage("Shotgun Unlocked!");
        }
        if (enemiesKilled == 100 && !machinegunUnlocked)
        {
            machinegunUnlocked = true;
            ShowWeaponUnlockMessage("Machinegun Unlocked!");
        }
    }

    private void ShowWeaponUnlockMessage(string message)
    {
        weaponUnlockText.SetActive(true);
        weaponUnlockText.GetComponent<TMP_Text>().text = message;
        StartCoroutine(HideWeaponUnlockText());
    }

    private IEnumerator HideWeaponUnlockText()
    {
        yield return new WaitForSeconds(2f); // Wait for 2 seconds
        weaponUnlockText.SetActive(false);  // Hide the text after 2 seconds
    }

}