using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private GameObject powerupUI; // Reference to the UI Canvas
    [SerializeField] private Button[] buttons; // Buttons for power-up selection
    [SerializeField] private PowerUps[] powerupPool; // Pool of all power-ups

    private PowerUps[] currentPowerups;

    private void OnEnable()
    {
     ShowPowerupChoices();
    }

    public void ShowPowerupChoices()
    {
        powerupUI.SetActive(true);

        // Create a temporary list of power-ups to ensure unique selection
        List<PowerUps> tempPowerupPool = new List<PowerUps>(powerupPool);

        currentPowerups = new PowerUps[2];

        for (int i = 0; i < 2; i++)
        {
            // Randomly select a power-up
            int randomIndex = Random.Range(0, tempPowerupPool.Count);
            currentPowerups[i] = tempPowerupPool[randomIndex];

            // Remove the selected power-up to avoid duplicates
            tempPowerupPool.RemoveAt(randomIndex);

            // Update button with the selected power-up
            int index = i; // Capture index for closure
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => ChoosePowerup(index));
            buttons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = currentPowerups[i].name;
            buttons[i].GetComponentInChildren<Image>().sprite = currentPowerups[i].icon;
        }
    }

    public void ChoosePowerup(int index)
    {
        currentPowerups[index].Apply(); // Apply the selected power-up
        powerupUI.SetActive(false); // Hide the UI
    }
}
