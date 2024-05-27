using UnityEngine;

public class ShowPanelOnCollision : MonoBehaviour
{
    public GameObject panel; // Panelin referans�

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Paneli ba�lang��ta gizle
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (panel != null)
            {
                panel.SetActive(true); // Paneli g�ster
            }
        }
    }
}
