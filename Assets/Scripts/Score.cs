using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class Score : MonoBehaviour
{

    public TMP_Text currentScoreText;
    public TMP_Text highScoreText;
    private int currentScore = 0;
    private int highScore = 0;
    private bool isGameOver = false;
    public bool DoublePoints = false;

    private string highScoreFilePath;  // S�kv�gen till filen

 


    void Start()
    {
       
        // Best�m var filen ska sparas (t.ex. Application.persistentDataPath ger en s�ker mapp f�r sparfiler)
        highScoreFilePath = Path.Combine(Application.persistentDataPath, "highscore.txt");

        ReadHighScore();

        highScoreText.text = "Highscore: " + highScore;

        InvokeRepeating("IncreaseScore", 1f, 5f);
    }
    public void AddPoints(int points)
    {
        if (DoublePoints)
        {
            Debug.Log("Double Points is active! Doubling points.");
            points *= 2; // Dubblar po�ngen
        }
        else
        {
           // Debug.Log("Double Points is not active.");
        }

        currentScore += points;
        
       // Debug.Log("Points added: " + points + ", Current Score: " + currentScore);
        currentScoreText.text = "Score: " + currentScore; // Uppdatera texten
    }



public int GetScore()
    {
        return currentScore;
    }

    void IncreaseScore()
    {
        if (!isGameOver)
        {
            AddPoints(100); // Anv�nd AddPoints ist�llet f�r direkt tilldelning
            currentScoreText.text = "Score: " + currentScore;
        }
    }

    public void GameOver()
    {
        isGameOver = true;

        // Om nuvarande po�ng �r h�gre �n highscore, uppdatera och spara det
        if (currentScore > highScore)
        {
            highScore = currentScore;
            SaveHighScore();
        }


        currentScoreText.text = "Final Score: " + currentScore;
        highScoreText.text = "Highscore: " + highScore;
    }

    // Funktion f�r att l�sa highscore fr�n fil
    void ReadHighScore()
    {
        if (File.Exists(highScoreFilePath))
        {
            string savedHighScore = File.ReadAllText(highScoreFilePath);
            if (int.TryParse(savedHighScore, out int savedScore))
            {
                highScore = savedScore;
            }
        }
        else
        {

            highScore = 0;
        }
    }


    void SaveHighScore()
    {

        File.WriteAllText(highScoreFilePath, highScore.ToString());
    }
}

