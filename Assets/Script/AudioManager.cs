using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Baþlangýçta ses çalma
        audioSource.Play();
    }

    void Update()
    {
        // Örneðin, bir tuþa basýldýðýnda sesi durdur
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Stop();
        }
    }
}
