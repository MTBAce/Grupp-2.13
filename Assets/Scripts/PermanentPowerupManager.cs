using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class PermanentPowerupManager : MonoBehaviour
{
    public List<PermanentPowerupData> powerupPool;
    public GameObject powerupUI;
    public UnityEngine.UI.Button[] buttons;

    private void Start()
    {
        ShowPowerUpOptions();   
    }

    public void ShowPowerUpOptions()
    {
        powerupUI.SetActive(true);

        PermanentPowerupData[] selectedPowerups = new PermanentPowerupData[2];
        for (int i = 0; i < 2; i++)
        {
            selectedPowerups[i] = powerupPool[Random.Range(0, powerupPool.Count)];
            int index = i;
            buttons[i].onClick.RemoveAllListeners();
            buttons[i].onClick.AddListener(() => ChoosePowerup(selectedPowerups[index]));
            buttons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = selectedPowerups[i].powerupName;
            buttons[i].GetComponentInChildren<UnityEngine.UI.Image>().sprite = selectedPowerups[i].powerUpIcon;
        }
        
    }

    public void ChoosePowerup(PermanentPowerupData powerup)
    {
        powerup.ApplyPowerUp(GameObject.FindWithTag("Player"));
        powerupUI.SetActive(false);
    }


}
