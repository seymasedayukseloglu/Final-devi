using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0; // Skor deðiþkeni

    // Skoru artýran fonksiyon
    public void IncreaseScore()
    {
        score++;
        Debug.Log("Skor artýrýldý! Yeni Skor: " + score);
    }

    // Skoru sýfýrlayan fonksiyon
    public void ResetScore()
    {
        score = 0;
        Debug.Log("Skor sýfýrlandý!");
    }

    // Skoru döndüren fonksiyon
    public int GetScore()
    {
        return score;
    }
}
