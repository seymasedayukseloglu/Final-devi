using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button toggleButton; // Buton referans�
    public GameObject panel; // G�sterilecek/gizlenecek panel


    void Start()
    {
        // Butona t�klama olay�n� dinle
        toggleButton.onClick.AddListener(TogglePanel);

        // Oyun ba�lad���nda paneli gizle
        panel.SetActive(false);
    }

    void TogglePanel()
    {
        // Panelin aktif durumunu tersine �evir
        panel.SetActive(!panel.activeSelf);
    }
}
