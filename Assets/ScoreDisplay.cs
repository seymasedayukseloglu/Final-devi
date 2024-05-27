using UnityEngine;
using UnityEngine.UI; // UI elemanlarýný kullanmak için gerekli using yönergesi

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText; // Skoru göstermek için UI metin bileþeni

    // Skoru ekranda gösteren fonksiyon
    public void DisplayScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
