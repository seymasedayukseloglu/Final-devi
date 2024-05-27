using UnityEngine;
using UnityEngine.UI; // UI elemanlar�na eri�im i�in gerekli
using UnityEngine.SceneManagement; // Sahne y�netimi i�in gerekli

public class ScoreTimeDikkat : MonoBehaviour
{
    public UIScript MyUI;
    public Text timerText; // Zaman� g�steren text
    public Text scoreText; // Skoru g�steren text
    public Button startButton; // Ba�la butonu
    public GameObject finishPanel; // Biti� paneli
    public AudioSource musicSource1; // Birinci m�zi�i �alan AudioSource
    public AudioSource musicSource2; // �kinci m�zi�i �alan AudioSource


    float Timer = 70f; // Ba�lang��ta 70 saniye
    private int score = 0; // Ba�lang��ta 0 puan
    bool IsTimerRunning = false; // Ba�lang��ta zamanlay�c� durdurulmu�

    // Start is called before the first frame update
    void Start()
    {
        // Text alanlar�n� ba�lang�� de�erleriyle g�ncelle
        timerText.text = "Time: " + ((int)Timer).ToString(); // Zaman� tam say� olarak g�ster
        scoreText.text = "Score: " + score.ToString();

        // Ba�la butonunun t�klanma olay�n� dinle
        startButton.onClick.AddListener(StartTimer);

    }

    // Update is called once per frame
 
    void Update()
    {
        if (IsTimerRunning)
        {
            Timer -= Time.deltaTime; // Zaman� azalt

            if (timerText != null)
            {
                timerText.text = "Time: " + ((int)Timer).ToString(); // Zaman� tam say� olarak g�ster
            }

            if (Timer <= 0f)
            {
                IsTimerRunning = false;
                Timer = 0f; // Timer'in negatif olmamas�n� sa�la
                if (timerText != null)
                {
                    timerText.text = "Time: " + ((int)Timer).ToString(); // UI'yi son kez g�ncelle
                }
                StopAllMusic();

                // Zaman doldu�unda ikinci sahneye ge�i� yap
                SceneManager.LoadScene("SceneG�r�s"); // �kinci sahnenin ad�n� buraya yaz�n
            }
        }
    }

    // Zamanlay�c�y� ba�latan metod
    void StartTimer()
    {
        IsTimerRunning = true;
    }

    // Biti� panelini g�steren metod
 

    // T�m m�zikleri durduran metod
    void StopAllMusic()
    {
        if (musicSource1 != null && musicSource1.isPlaying)
        {
            musicSource1.Stop();
        }

        if (musicSource2 != null && musicSource2.isPlaying)
        {
            musicSource2.Stop();
        }
    }
}