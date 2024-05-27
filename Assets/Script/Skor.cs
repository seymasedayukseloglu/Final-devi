using UnityEngine;
using UnityEngine.UI;

public class Skor : MonoBehaviour
{
    private int score = 0; // Skor deðeri
    public Text scoreText; // Skorun gösterileceði Text bileþeni

    // Skoru 1 artýr ve Text bileþenini güncelle
    public void IncrementScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        Debug.Log("Score: " + score);
    }

    // Butona týklandýðýnda skoru artýran metot
    public void OnScoreButtonClicked()
    {
        IncrementScore(); // Skoru artýr
    }
}
