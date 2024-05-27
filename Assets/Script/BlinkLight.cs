using UnityEngine;

public class BlinkLight : MonoBehaviour
{
    public Light lightToBlink;  // Bu de�i�kene sahnedeki ���k nesnesini atayaca��z.
    public float blinkInterval = 1f;  // Yan�p s�nme aral��� (saniye cinsinden).
    private float timer;
    private bool isBlinking = true;

    void Start()
    {
        if (lightToBlink == null)
        {
            lightToBlink = GetComponent<Light>();  // I��k componentini al.
        }
        timer = blinkInterval;  // Ba�lang��ta timer'� aral�k s�resine ayarla.
    }

    void Update()
    {
        if (isBlinking)
        {
            timer -= Time.deltaTime;  // Timer'� ge�en zamana g�re azalt.

            if (timer <= 0)
            {
                lightToBlink.enabled = !lightToBlink.enabled;  // I����n durumunu tersine �evir.
                timer = blinkInterval;  // Timer'� yeniden ayarla.
            }
        }
    }

    public void SetBlinking(bool blinking)
    {
        isBlinking = blinking;
        if (!blinking)
        {
            lightToBlink.enabled = false;  // I���� kapat
        }
    }
}
