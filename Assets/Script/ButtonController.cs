using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button toggleButton; // Buton referansý
    public GameObject panel; // Gösterilecek/gizlenecek panel


    void Start()
    {
        // Butona týklama olayýný dinle
        toggleButton.onClick.AddListener(TogglePanel);

        // Oyun baþladýðýnda paneli gizle
        panel.SetActive(false);
    }

    void TogglePanel()
    {
        // Panelin aktif durumunu tersine çevir
        panel.SetActive(!panel.activeSelf);
    }
}
