
using UnityEngine;

public class LightControl : MonoBehaviour
{
  

    public float flickerSpeed = 1f; // Yan�p s�nen h�z

    private bool isFlickering = true;

    void Start()
    {
        InvokeRepeating("FlickerLights", 0f, flickerSpeed);
        Invoke("StopFlickering", 10f);
    }


    void Update()
    {
        if (isFlickering)
        {
            // Yan�p s�nen ���klar�n i�lemleri burada ger�ekle�tirilebilir
        }
    }


    void FlickerLights()
    {
        foreach (Transform child in transform)
        {
            Light lightComponent = child.GetComponent<Light>();

            if (lightComponent != null)
            {
                lightComponent.enabled = !lightComponent.enabled;
            }
        }
    }

    void StopFlickering()
    {
        isFlickering = false;
    }
}