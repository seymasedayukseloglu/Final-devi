using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGirisSayaci : MonoBehaviour
{
    // Door (1) nesnesine referans
    public GameObject door;

    void Start()
    {
  
        // PlayerPrefs'ten �nceki �al��t�rma say�s�n� s�f�rla
        PlayerPrefs.DeleteKey("CalistirmaSayaci");


        // Her SceneGirisSayaci sahnesine girdi�inizde saya� s�f�rlan�r
        ResetCounterIfNeeded();

        // PlayerPrefs'ten �nceki �al��t�rma say�s�n� al
        int calistirmaSayisi = PlayerPrefs.GetInt("CalistirmaSayaci", 0);

        // �al��t�rma say�s�n� artt�r
        calistirmaSayisi++;

        // Yeni �al��t�rma say�s�n� PlayerPrefs'e kaydet
        PlayerPrefs.SetInt("CalistirmaSayaci", calistirmaSayisi);

        // PlayerPrefs'i kaydet
        PlayerPrefs.Save();

        // Konsola �al��t�rma say�s�n� ve oyun ba�lad� mesaj�n� yazd�r
        Debug.Log("SceneG�r�s sahnesi ba�lat�ld�! Bu oyun " + calistirmaSayisi + " kez ba�lat�ld�.");

        // E�er �al��t�rma say�s� 2 ise door nesnesini gizle
        if (calistirmaSayisi == 2)
        {
            door.SetActive(false);
        }
    }

    // PlayerPrefs s�f�rlamak istendi�inde bu i�levi kullanabilirsiniz
    public void SifirlaCalistirmaSayaci()
    {
        PlayerPrefs.DeleteKey("CalistirmaSayaci");
    }

    // Saya� her SceneGirisSayaci sahnesine girdi�inizde s�f�rlan�r
    void ResetCounterIfNeeded()
    {
        if (SceneManager.GetActiveScene().name == "SceneGirisSayaci")
        {
            PlayerPrefs.DeleteKey("CalistirmaSayaci");
        }
    }
}
