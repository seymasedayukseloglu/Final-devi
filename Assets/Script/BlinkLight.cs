using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public Light lightToBlink;  // Bu deðiþkene sahnedeki ýþýk nesnesini atayacaðýz.
    public float blinkInterval = 1f;  // Yanýp sönme aralýðý (saniye cinsinden).
    private float timer;
    private bool isBlinking = true;

    void Start()
    {
        if (lightToBlink == null)
        {
            lightToBlink = GetComponent<Light>();  // Iþýk componentini al.
        }
        timer = blinkInterval;  // Baþlangýçta timer'ý aralýk süresine ayarla.
    }

    void Update()
    {
        if (isBlinking)
        {
            timer -= Time.deltaTime;  // Timer'ý geçen zamana göre azalt.

            if (timer <= 0)
            {
                lightToBlink.enabled = !lightToBlink.enabled;  // Iþýðýn durumunu tersine çevir.
                timer = blinkInterval;  // Timer'ý yeniden ayarla.
            }
        }
    }

    public void SetBlinking(bool blinking)
    {
        isBlinking = blinking;
        if (!blinking)
        {
            lightToBlink.enabled = false;  // Iþýðý kapat
        }
    }
}
