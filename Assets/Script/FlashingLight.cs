using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public Light targetLight;
    public float flashSpeed = 1.0f;
    private float timer;

    private Color[] colors = new Color[] { Color.red, Color.blue, Color.green, Color.yellow };

    void Start()
    {
        if (targetLight == null)
        {
            targetLight = GetComponent<Light>();
        }
        timer = 0;
    }

    void Update()
    {
        timer += Time.deltaTime * flashSpeed;
        int colorIndex = Mathf.FloorToInt(timer) % colors.Length;
        targetLight.color = colors[colorIndex];
    }
}
