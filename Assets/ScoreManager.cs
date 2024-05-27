using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int score = 0; // Skor de�i�keni

    // Skoru art�ran fonksiyon
    public void IncreaseScore()
    {
        score++;
        Debug.Log("Skor art�r�ld�! Yeni Skor: " + score);
    }

    // Skoru s�f�rlayan fonksiyon
    public void ResetScore()
    {
        score = 0;
        Debug.Log("Skor s�f�rland�!");
    }

    // Skoru d�nd�ren fonksiyon
    public int GetScore()
    {
        return score;
    }
}
