using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGirisSayaci : MonoBehaviour
{
    // Door (1) nesnesine referans
    public GameObject door;

    void Start()
    {
  
        // PlayerPrefs'ten önceki çalýþtýrma sayýsýný sýfýrla
        PlayerPrefs.DeleteKey("CalistirmaSayaci");


        // Her SceneGirisSayaci sahnesine girdiðinizde sayaç sýfýrlanýr
        ResetCounterIfNeeded();

        // PlayerPrefs'ten önceki çalýþtýrma sayýsýný al
        int calistirmaSayisi = PlayerPrefs.GetInt("CalistirmaSayaci", 0);

        // Çalýþtýrma sayýsýný arttýr
        calistirmaSayisi++;

        // Yeni çalýþtýrma sayýsýný PlayerPrefs'e kaydet
        PlayerPrefs.SetInt("CalistirmaSayaci", calistirmaSayisi);

        // PlayerPrefs'i kaydet
        PlayerPrefs.Save();

        // Konsola çalýþtýrma sayýsýný ve oyun baþladý mesajýný yazdýr
        Debug.Log("SceneGýrýs sahnesi baþlatýldý! Bu oyun " + calistirmaSayisi + " kez baþlatýldý.");

        // Eðer çalýþtýrma sayýsý 2 ise door nesnesini gizle
        if (calistirmaSayisi == 2)
        {
            door.SetActive(false);
        }
    }

    // PlayerPrefs sýfýrlamak istendiðinde bu iþlevi kullanabilirsiniz
    public void SifirlaCalistirmaSayaci()
    {
        PlayerPrefs.DeleteKey("CalistirmaSayaci");
    }

    // Sayaç her SceneGirisSayaci sahnesine girdiðinizde sýfýrlanýr
    void ResetCounterIfNeeded()
    {
        if (SceneManager.GetActiveScene().name == "SceneGirisSayaci")
        {
            PlayerPrefs.DeleteKey("CalistirmaSayaci");
        }
    }
}
