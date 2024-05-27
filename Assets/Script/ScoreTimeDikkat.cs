using UnityEngine;
using UnityEngine.UI; // UI elemanlarýna eriþim için gerekli
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class ScoreTimeDikkat : MonoBehaviour
{
    public UIScript MyUI;
    public Text timerText; // Zamaný gösteren text
    public Text scoreText; // Skoru gösteren text
    public Button startButton; // Baþla butonu
    public GameObject finishPanel; // Bitiþ paneli
    public AudioSource musicSource1; // Birinci müziði çalan AudioSource
    public AudioSource musicSource2; // Ýkinci müziði çalan AudioSource


    float Timer = 70f; // Baþlangýçta 70 saniye
    private int score = 0; // Baþlangýçta 0 puan
    bool IsTimerRunning = false; // Baþlangýçta zamanlayýcý durdurulmuþ

    // Start is called before the first frame update
    void Start()
    {
        // Text alanlarýný baþlangýç deðerleriyle güncelle
        timerText.text = "Time: " + ((int)Timer).ToString(); // Zamaný tam sayý olarak göster
        scoreText.text = "Score: " + score.ToString();

        // Baþla butonunun týklanma olayýný dinle
        startButton.onClick.AddListener(StartTimer);

    }

    // Update is called once per frame
 
    void Update()
    {
        if (IsTimerRunning)
        {
            Timer -= Time.deltaTime; // Zamaný azalt

            if (timerText != null)
            {
                timerText.text = "Time: " + ((int)Timer).ToString(); // Zamaný tam sayý olarak göster
            }

            if (Timer <= 0f)
            {
                IsTimerRunning = false;
                Timer = 0f; // Timer'in negatif olmamasýný saðla
                if (timerText != null)
                {
                    timerText.text = "Time: " + ((int)Timer).ToString(); // UI'yi son kez güncelle
                }
                StopAllMusic();

                // Zaman dolduðunda ikinci sahneye geçiþ yap
                SceneManager.LoadScene("SceneGýrýs"); // Ýkinci sahnenin adýný buraya yazýn
            }
        }
    }

    // Zamanlayýcýyý baþlatan metod
    void StartTimer()
    {
        IsTimerRunning = true;
    }

    // Bitiþ panelini gösteren metod
 

    // Tüm müzikleri durduran metod
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