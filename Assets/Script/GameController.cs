using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public GameObject panelPrefab; // Prefab olarak panel
    public Text soruText; // Text referans�
    public Button correctAnswerButton; // Do�ru cevap butonu
    public Button wrongAnswerButton; // Yanl�� cevap butonu
    public List<string> textMessages; // G�sterilecek metinler
    public List<string> buttonMessages; // G�sterilecek buttonlar
    public BlinkLight blinkLight; // BlinkLight script'ine referans
    public Skor scoreScript; // Skor script'ine referans

    public float displayInterval = 7f; // Panelin g�r�nme aral���
    public float displayDuration = 4f; // Panelin ekranda kalma s�resi
    public List<Done_BGScroller> bgScrollers; // Birden fazla Done_BGScroller script'ine referans
    public List<Vector3> buttonPositions; // Butonlar�n pozisyonlar� i�in liste

    private GameObject text;
    private int currentTextIndex = 0; // Metin listesi i�in index
    private int currentButtonIndex = 0; // Button listesi i�in index
    private int currentPositionIndex = 0; // Pozisyon listesi i�in index
    private bool isButtonClicked = false; // Butonlar�n sadece bir kez t�klanabilmesi i�in

    public void StartGame()
    {
        StartCoroutine(PanelLifecycle());
    }

    IEnumerator PanelLifecycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(displayInterval);
            ShowPanel();
            yield return new WaitForSeconds(displayDuration);
            if (!isButtonClicked) // Sadece e�er buton t�klanmad�ysa paneli gizle
            {
                HidePanel();
            }
        }
    }

    void ShowPanel()
    {
        text = Instantiate(panelPrefab, Vector3.zero, Quaternion.identity, transform);
        Debug.Log("Panel geldi");

        // Paneldeki metni g�ncelle
        if (text != null && textMessages.Count > 0)
        {
            soruText.text = textMessages[currentTextIndex];
            currentTextIndex = (currentTextIndex + 1) % textMessages.Count;
        }

        // Butonlar�n metinlerini g�ncelle
        if (buttonMessages.Count >= 2)
        {
            correctAnswerButton.GetComponentInChildren<Text>().text = buttonMessages[currentButtonIndex];
            wrongAnswerButton.GetComponentInChildren<Text>().text = buttonMessages[(currentButtonIndex + 1) % buttonMessages.Count];
            currentButtonIndex = (currentButtonIndex + 2) % buttonMessages.Count;
        }

        // Butonlar�n pozisyonlar�n� g�ncelle
        if (buttonPositions.Count >= 2)
        {
            correctAnswerButton.transform.position = buttonPositions[currentPositionIndex];
            wrongAnswerButton.transform.position = buttonPositions[(currentPositionIndex + 1) % buttonPositions.Count];
            currentPositionIndex = (currentPositionIndex + 2) % buttonPositions.Count;
        }

        // Butonlar�n t�klama olaylar�n� ekleyin
        correctAnswerButton.onClick.RemoveAllListeners();
        wrongAnswerButton.onClick.RemoveAllListeners();
        correctAnswerButton.onClick.AddListener(OnCorrectAnswerButtonClick);
        wrongAnswerButton.onClick.AddListener(OnWrongAnswerButtonClick);
        isButtonClicked = false;

        SetScrolling(false); // Panel g�r�n�rken kaymay� durdur

        // I���� kapat
        if (blinkLight != null)
        {
            blinkLight.SetBlinking(false);
        }
    }

    void HidePanel()
    {
        if (text != null)
        {
            Destroy(text);
            Debug.Log("Panel gitti");
            SetScrolling(true); // Panel kayboldu�unda kaymay� tekrar ba�lat

            // I���� tekrar a�
            if (blinkLight != null)
            {
                blinkLight.SetBlinking(true);
            }
        }
    }

    void SetScrolling(bool scrolling)
    {
        Debug.Log("SetScrolling called with value: " + scrolling);
        foreach (var bgScroller in bgScrollers)
        {
            bgScroller.SetScrolling(scrolling);
        }
    }

    // Do�ru cevap butonuna t�kland���nda �a�r�lan fonksiyon
    void OnCorrectAnswerButtonClick()
    {
        if (!isButtonClicked)
        {
            scoreScript.IncrementScore();
            isButtonClicked = true;
            HidePanel(); // Paneli hemen yok et
        }
    }

    // Yanl�� cevap butonuna t�kland���nda �a�r�lan fonksiyon
    void OnWrongAnswerButtonClick()
    {
        if (!isButtonClicked)
        {
            Debug.Log("Wrong answer clicked");
            isButtonClicked = true;
            HidePanel(); // Paneli hemen yok et
        }
    }
}
