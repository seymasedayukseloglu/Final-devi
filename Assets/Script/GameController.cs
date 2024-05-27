using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public GameObject panelPrefab; // Prefab olarak panel
    public Text soruText; // Text referansý
    public Button correctAnswerButton; // Doðru cevap butonu
    public Button wrongAnswerButton; // Yanlýþ cevap butonu
    public List<string> textMessages; // Gösterilecek metinler
    public List<string> buttonMessages; // Gösterilecek buttonlar
    public BlinkLight blinkLight; // BlinkLight script'ine referans
    public Skor scoreScript; // Skor script'ine referans

    public float displayInterval = 7f; // Panelin görünme aralýðý
    public float displayDuration = 4f; // Panelin ekranda kalma süresi
    public List<Done_BGScroller> bgScrollers; // Birden fazla Done_BGScroller script'ine referans
    public List<Vector3> buttonPositions; // Butonlarýn pozisyonlarý için liste

    private GameObject text;
    private int currentTextIndex = 0; // Metin listesi için index
    private int currentButtonIndex = 0; // Button listesi için index
    private int currentPositionIndex = 0; // Pozisyon listesi için index
    private bool isButtonClicked = false; // Butonlarýn sadece bir kez týklanabilmesi için

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
            if (!isButtonClicked) // Sadece eðer buton týklanmadýysa paneli gizle
            {
                HidePanel();
            }
        }
    }

    void ShowPanel()
    {
        text = Instantiate(panelPrefab, Vector3.zero, Quaternion.identity, transform);
        Debug.Log("Panel geldi");

        // Paneldeki metni güncelle
        if (text != null && textMessages.Count > 0)
        {
            soruText.text = textMessages[currentTextIndex];
            currentTextIndex = (currentTextIndex + 1) % textMessages.Count;
        }

        // Butonlarýn metinlerini güncelle
        if (buttonMessages.Count >= 2)
        {
            correctAnswerButton.GetComponentInChildren<Text>().text = buttonMessages[currentButtonIndex];
            wrongAnswerButton.GetComponentInChildren<Text>().text = buttonMessages[(currentButtonIndex + 1) % buttonMessages.Count];
            currentButtonIndex = (currentButtonIndex + 2) % buttonMessages.Count;
        }

        // Butonlarýn pozisyonlarýný güncelle
        if (buttonPositions.Count >= 2)
        {
            correctAnswerButton.transform.position = buttonPositions[currentPositionIndex];
            wrongAnswerButton.transform.position = buttonPositions[(currentPositionIndex + 1) % buttonPositions.Count];
            currentPositionIndex = (currentPositionIndex + 2) % buttonPositions.Count;
        }

        // Butonlarýn týklama olaylarýný ekleyin
        correctAnswerButton.onClick.RemoveAllListeners();
        wrongAnswerButton.onClick.RemoveAllListeners();
        correctAnswerButton.onClick.AddListener(OnCorrectAnswerButtonClick);
        wrongAnswerButton.onClick.AddListener(OnWrongAnswerButtonClick);
        isButtonClicked = false;

        SetScrolling(false); // Panel görünürken kaymayý durdur

        // Iþýðý kapat
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
            SetScrolling(true); // Panel kaybolduðunda kaymayý tekrar baþlat

            // Iþýðý tekrar aç
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

    // Doðru cevap butonuna týklandýðýnda çaðrýlan fonksiyon
    void OnCorrectAnswerButtonClick()
    {
        if (!isButtonClicked)
        {
            scoreScript.IncrementScore();
            isButtonClicked = true;
            HidePanel(); // Paneli hemen yok et
        }
    }

    // Yanlýþ cevap butonuna týklandýðýnda çaðrýlan fonksiyon
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
