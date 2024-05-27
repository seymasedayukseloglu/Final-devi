using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel;
    public float displayInterval = 15f; // Panelin görünme aralýðý (15 saniye)
    public float displayDuration = 10f; // Panelin ekranda kalma süresi (10 saniye)

    private float timer;
    private bool isPanelVisible = false;

    void Start()
    {
        timer = displayInterval;
        panel.SetActive(false);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (isPanelVisible && timer <= 0)
        {
            panel.SetActive(false);
            isPanelVisible = false;
            timer = displayInterval;
        }
        else if (!isPanelVisible && timer <= 0)
        {
            panel.SetActive(true);
            isPanelVisible = true;
            timer = displayDuration;
        }
    }
}

