using UnityEngine;
using UnityEngine.UI;

public class Skor : MonoBehaviour
{
    private int score = 0; // Skor de�eri
    public Text scoreText; // Skorun g�sterilece�i Text bile�eni

    // Skoru 1 art�r ve Text bile�enini g�ncelle
    public void IncrementScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        Debug.Log("Score: " + score);
    }

    // Butona t�kland���nda skoru art�ran metot
    public void OnScoreButtonClicked()
    {
        IncrementScore(); // Skoru art�r
    }
}
