using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float scrollSpeed;
    public float startPositionZ;
    public float resetPositionZ;

    private bool isScrolling = true; // Kayma kontrol� i�in boolean

    void Update()
    {
        if (isScrolling)
        {
            // Zamanla azalan bir de�er elde etmek i�in Mathf.Lerp kullan�l�r
            float newPositionZ = Mathf.Lerp(resetPositionZ, startPositionZ, Time.time * scrollSpeed);
            // Arka plan�n z pozisyonunu g�ncelle
            transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
        }
    }

    public void SetScrolling(bool scrolling)
    {
        isScrolling = scrolling;
    }
}
