using System.Collections;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(-44.9f, 0, 0);
    public Vector3 endPosition = new Vector3(-583.5f, 0, 0);
    public float speed = 1.0f;
    public float appearTime = 5.0f; // Balýðýn görüneceði zaman

    private bool isMoving = false;

    void Start()
    {
        transform.position = startPosition;
        SetVisibility(false); // Balýðý baþlangýçta görünmez yap
        StartCoroutine(StartMovementAfterDelay(appearTime));
    }

    IEnumerator StartMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetVisibility(true); // Belirli bir süre sonra balýðý görünür yap
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPosition, step);

            if (transform.position == endPosition)
            {
                isMoving = false; // Hedef pozisyona ulaþtýðýnda hareketi durdur
                Destroy(gameObject); // Balýðý sahneden sil
            }
        }
    }

    void SetVisibility(bool visible)
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = visible;
        }
    }
}
