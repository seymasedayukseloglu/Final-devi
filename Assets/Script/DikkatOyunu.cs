using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // UI elemanlar�na eri�im i�in gerekli

public class DikkatOyunu : MonoBehaviour
{
    public GameObject[] boxes; // Renkli kutular�n listesi
    public float flashDuration = 0.5f; // Kutular�n yan�p s�nme s�resi
    public float pauseDuration = 0.5f; // Kutular aras�ndaki duraklama s�resi
    public int initialSequenceLength = 4; // Ba�lang��ta yan�p s�nme s�ras�n�n uzunlu�u
    public float levelIncreaseInterval = 10f; // Zorluk seviyesinin art�r�laca�� aral�k

    public UIScript MyUI;
    public Text timeText; // Zaman� g�steren text
    public Text scoreText; // Skoru g�steren text
    bool IsTimerRunning = true;

    private float Timer = 100f; // Ba�lang��ta 60 saniye
    private int score = 0; // Ba�lang��ta 0 puan

    private List<int> sequence = new List<int>(); // Do�ru s�ray� tutan liste
    private int currentIndex = 0; // Oyuncunun do�ru s�radaki konumu
    private bool playerTurn = false; // Oyuncunun s�ras� m� yoksa kutular�n m� yan�p s�nd���

    void Start()
    {
        // Text alanlar�n� ba�lang�� de�erleriyle g�ncelle
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
            yield return StartCoroutine(FlashBox(sequence[i])); // Tek bir kutuyu yan�p s�nd�r
            yield return new WaitForSeconds(pauseDuration);
        }
        playerTurn = true; // Oyuncunun s�ras�
    }


    IEnumerator FlashBox(int index)
    {
        // Tek bir kutuyu yan�p s�nd�rme i�lemi
        Renderer rend = boxes[index].GetComponent<Renderer>();
        Color originalColor = rend.material.color;
        rend.material.color = Color.white;
        yield return new WaitForSeconds(flashDuration);
        rend.material.color = originalColor;
    }

    void IncreaseDifficulty()
    {
        // Zorluk seviyesini art�rma i�lemi (�rne�in sequenceLength'i art�rabilirsiniz)
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
                Debug.Log("Do�ru s�ra tamamland�!");
                score++;
                scoreText.text = "Score: " + score.ToString();
                currentIndex = 0;
                playerTurn = false;
                StartCoroutine(FlashSequence());
            }
        }
        else
        {
            Debug.Log("Yanl�� s�ra! Oyun bitti.");
            // Oyunu s�f�rlama veya ba�ka bir i�lem yapma
        }
    }

    void Update()
    {
        if (IsTimerRunning)
        {
            Timer -= Time.deltaTime; // Zaman� azalt
            MyUI.UpdateTimer(Timer);

            if (Timer <= 0f)
            {
                IsTimerRunning = false;
                // Zaman doldu�unda ikinci sahneye ge�i� yap
                SceneManager.LoadScene("SceneG�r�sDikkat"); // �kinci sahnenin ad�n� buraya yaz�n
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
