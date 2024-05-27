using UnityEngine;
using UnityEngine.SceneManagement;

public class OyunBitimi : MonoBehaviour
{
    private float timer = 60f;

    void Start()
    {
        Debug.Log("OyunBitimi script started. Timer set to: " + timer);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log("Timer: " + timer);

        if (timer <= 0f)
        {
            Debug.Log("Time's up! Loading scene: SceneGýrýsKart");
            SceneManager.LoadScene("SceneGýrýsKart");
        }
    }
}
