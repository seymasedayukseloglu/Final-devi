using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTimeHesaplama1 : MonoBehaviour
{
    public MathProblemManager mathProblemManager;
    public Text timeText; // Zamaný gösteren text
    public Text scoreText; // Skoru gösteren text

    float Timer = 65f; // Baþlangýçta 65 saniye
    private int score = 0; // Baþlangýçta 0 puan
    bool IsTimerRunning = true;

    void Start()
    {
        // Referanslarýn atanýp atanmadýðýný kontrol etmek için debug logu ekle
        if (timeText == null)
        {
            Debug.LogError("timeText Inspector'da atanmadý!");
        }
        else
        {
            timeText.text = "Time: " + ((int)Timer).ToString(); // Zamaný tam sayý olarak göster
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText Inspector'da atanmadý!");
        }
        else
        {
            scoreText.text = "Score: " + score.ToString();
        }

        if (mathProblemManager == null)
        {
            Debug.LogError("mathProblemManager Inspector'da atanmadý!");
        }
    }

    void Update()
    {
        if (IsTimerRunning)
        {
            Timer -= Time.deltaTime; // Zamaný azalt

            if (timeText != null)
            {
                timeText.text = "Time: " + ((int)Timer).ToString(); // Zamaný tam sayý olarak göster
            }

            if (Timer <= 0f)
            {
                IsTimerRunning = false;
                Timer = 0f; // Timer'in negatif olmamasýný saðla
                if (timeText != null)
                {
                    timeText.text = "Time: " + ((int)Timer).ToString(); // UI'yi son kez güncelle
                }

                // Zaman dolduðunda ikinci sahneye geçiþ yap
                SceneManager.LoadScene("SceneGýrýsHesaplama"); // Ýkinci sahnenin adýný buraya yazýn
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
            Debug.LogError("scoreText atanmadý!");
        }
        Debug.Log("Score: " + score);
    }
}