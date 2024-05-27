using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float scrollSpeed;
    public float startPositionZ;
    public float resetPositionZ;

    private bool isScrolling = true; // Kayma kontrolü için boolean

    void Update()
    {
        if (isScrolling)
        {
            // Zamanla azalan bir deðer elde etmek için Mathf.Lerp kullanýlýr
            float newPositionZ = Mathf.Lerp(resetPositionZ, startPositionZ, Time.time * scrollSpeed);
            // Arka planýn z pozisyonunu güncelle
            transform.position = new Vector3(transform.position.x, transform.position.y, newPositionZ);
        }
    }

    public void SetScrolling(bool scrolling)
    {
        isScrolling = scrolling;
    }
}
