using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Ba�lang��ta ses �alma
        audioSource.Play();
    }

    void Update()
    {
        // �rne�in, bir tu�a bas�ld���nda sesi durdur
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Stop();
        }
    }
}
