using UnityEngine;
using UnityEngine.UI;

public class GirisPanelController : MonoBehaviour
{
    public GameObject giri�Paneli;
    public Button ba�laButonu;
    public GameObject oyunPaneli; // Oyun ekran� paneli


    public GameController gameController; // GameController scriptine referans

    void Start()
    {
        ba�laButonu.onClick.AddListener(Ba�laOyunu);
        oyunPaneli.SetActive(false); // Oyun panelini ba�lang��ta gizle
        giri�Paneli.SetActive(true); // Giri� panelini ba�lang��ta g�ster

        // Ses butonu metnini ba�latma durumuna g�re ayarla
      
    }

    void Ba�laOyunu()
    {
        giri�Paneli.SetActive(false);
        oyunPaneli.SetActive(true);

        // GameController'da oyunu ba�latan fonksiyonu �a��r
        if (gameController != null)
        {
            gameController.StartGame();
        }
    }

    
}
