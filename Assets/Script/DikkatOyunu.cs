using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI elemanlarýna eriþim için gerekli

public class DikkatOyunu : MonoBehaviour
{
    public GameObject[] boxes; // Renkli kutularýn listesi
    public float flashDuration = 0.5f; // Kutularýn yanýp sönme süresi
    public float pauseDuration = 0.5f; // Kutular arasýndaki duraklama süresi
    public int initialSequenceLength = 4; // Baþlangýçta yanýp sönme sýrasýnýn uzunluðu
    public float levelIncreaseInterval = 10f; // Zorluk seviyesinin artýrýlacaðý aralýk

    public UIScript MyUI;
    public Text timeText; // Zamaný gösteren text
    public Text scoreText; // Skoru gösteren text
    bool IsTimerRunning = true;

    private float Timer = 100f; // Baþlangýçta 60 saniye
    private int score = 0; // Baþlangýçta 0 puan

    private List<int> sequence = new List<int>(); // Doðru sýrayý tutan liste
    private int currentIndex = 0; // Oyuncunun doðru sýradaki konumu
    private bool playerTurn = false; // Oyuncunun sýrasý mý yoksa kutularýn mý yanýp söndüðü

    void Start()
    {
        // Text alanlarýný baþlangýç deðerleriyle güncelle
        timeText.text = "Time: " + Timer.ToString();
        scoreText.text = "Score: " + score.ToString();

        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        while (true)
        {
            yield return StartCoroutine(FlashSequence());
            yield return new WaitForSeconds(levelIncreaseInterval);
            IncreaseDifficulty();
        }
    }

    IEnumerator FlashSequence()
    {
        sequence.Clear();
        for (int i = 0; i < initialSequenceLength; i++)
        {
            int randomIndex = Random.Range(0, boxes.Length);
            sequence.Add(randomIndex);
            yield return StartCoroutine(FlashBox(sequence[i])); // Tek bir kutuyu yanýp söndür
            yield return new WaitForSeconds(pauseDuration);
        }
        playerTurn = true; // Oyuncunun sýrasý
    }


    IEnumerator FlashBox(int index)
    {
        // Tek bir kutuyu yanýp söndürme iþlemi
        Renderer rend = boxes[index].GetComponent<Renderer>();
        Color originalColor = rend.material.color;
        rend.material.color = Color.white;
        yield return new WaitForSeconds(flashDuration);
        rend.material.color = originalColor;
    }

    void IncreaseDifficulty()
    {
        // Zorluk seviyesini artýrma iþlemi (örneðin sequenceLength'i artýrabilirsiniz)
        initialSequenceLength++;
    }

    void CheckInput(int index)
    {
        if (!playerTurn || currentIndex >= sequence.Count) return;

        if (index == sequence[currentIndex])
        {
            currentIndex++;
            if (currentIndex >= sequence.Count)
            {
                Debug.Log("Doðru sýra tamamlandý!");
                score++;
                scoreText.text = "Score: " + score.ToString();
                currentIndex = 0;
                playerTurn = false;
                StartCoroutine(FlashSequence());
            }
        }
        else
        {
            Debug.Log("Yanlýþ sýra! Oyun bitti.");
            // Oyunu sýfýrlama veya baþka bir iþlem yapma
        }
    }

    void Update()
    {
        if (IsTimerRunning)
        {
            Timer -= Time.deltaTime; // Zamaný azalt
            MyUI.UpdateTimer(Timer);

            if (Timer <= 0f)
            {
                IsTimerRunning = false;
                // Zaman dolduðunda ikinci sahneye geçiþ yap
                SceneManager.LoadScene("SceneGýrýsDikkat"); // Ýkinci sahnenin adýný buraya yazýn
            }
        }

        for (int i = 0; i < boxes.Length; i++)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == boxes[i])
                    {
                        CheckInput(i);
                    }
                }
            }
        }
    }
}
