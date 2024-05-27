using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTimeHesaplama1 : MonoBehaviour
{
    public MathProblemManager mathProblemManager;
    public Text timeText; // Zaman� g�steren text
    public Text scoreText; // Skoru g�steren text

    float Timer = 65f; // Ba�lang��ta 65 saniye
    private int score = 0; // Ba�lang��ta 0 puan
    bool IsTimerRunning = true;

    void Start()
    {
        // Referanslar�n atan�p atanmad���n� kontrol etmek i�in debug logu ekle
        if (timeText == null)
        {
            Debug.LogError("timeText Inspector'da atanmad�!");
        }
        else
        {
            timeText.text = "Time: " + ((int)Timer).ToString(); // Zaman� tam say� olarak g�ster
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText Inspector'da atanmad�!");
        }
        else
        {
            scoreText.text = "Score: " + score.ToString();
        }

        if (mathProblemManager == null)
        {
            Debug.LogError("mathProblemManager Inspector'da atanmad�!");
        }
    }

    void Update()
    {
        if (IsTimerRunning)
        {
            Timer -= Time.deltaTime; // Zaman� azalt

            if (timeText != null)
            {
                timeText.text = "Time: " + ((int)Timer).ToString(); // Zaman� tam say� olarak g�ster
            }

            if (Timer <= 0f)
            {
                IsTimerRunning = false;
                Timer = 0f; // Timer'in negatif olmamas�n� sa�la
                if (timeText != null)
                {
                    timeText.text = "Time: " + ((int)Timer).ToString(); // UI'yi son kez g�ncelle
                }

                // Zaman doldu�unda ikinci sahneye ge�i� yap
                SceneManager.LoadScene("SceneG�r�sHesaplama"); // �kinci sahnenin ad�n� buraya yaz�n
            }
        }
    }

    public void IncreaseScore()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("scoreText atanmad�!");
        }
        Debug.Log("Score: " + score);
    }
}