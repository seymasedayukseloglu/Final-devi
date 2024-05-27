using UnityEngine;
using UnityEngine.UI;

public class GirisPanelController : MonoBehaviour
{
    public GameObject giriþPaneli;
    public Button baþlaButonu;
    public GameObject oyunPaneli; // Oyun ekraný paneli


    public GameController gameController; // GameController scriptine referans

    void Start()
    {
        baþlaButonu.onClick.AddListener(BaþlaOyunu);
        oyunPaneli.SetActive(false); // Oyun panelini baþlangýçta gizle
        giriþPaneli.SetActive(true); // Giriþ panelini baþlangýçta göster

        // Ses butonu metnini baþlatma durumuna göre ayarla
      
    }

    void BaþlaOyunu()
    {
        giriþPaneli.SetActive(false);
        oyunPaneli.SetActive(true);

        // GameController'da oyunu baþlatan fonksiyonu çaðýr
        if (gameController != null)
        {
            gameController.StartGame();
        }
    }

    
}
