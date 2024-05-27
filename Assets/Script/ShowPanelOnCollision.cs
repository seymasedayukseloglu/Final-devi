using UnityEngine;

public class ShowPanelOnCollision : MonoBehaviour
{
    public GameObject panel; // Panelin referansý

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Paneli baþlangýçta gizle
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (panel != null)
            {
                panel.SetActive(true); // Paneli göster
            }
        }
    }
}
