using UnityEngine;
using UnityEngine.UI; // UI elemanlar�n� kullanmak i�in gerekli using y�nergesi

public class ScoreDisplay : MonoBehaviour
{
    public Text scoreText; // Skoru g�stermek i�in UI metin bile�eni

    // Skoru ekranda g�steren fonksiyon
    public void DisplayScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
