using UnityEngine;

public class BusMovement : MonoBehaviour
{
    public Vector3 startPosition = new Vector3(-44.9f, 0, 0);
    public Vector3 endPosition = new Vector3(-583.5f, 0, 0);
    public float speed = 1.0f;

    private bool isMoving = false;

    void Start()
    {
        transform.position = startPosition;
        isMoving = true; // Otobüs sahneye geldiðinde hemen hareket etmeye baþlar
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
                // Yeni otobüs oluþtur
                BusSpawner.Instance.SpawnBus();
                Destroy(gameObject); // Mevcut otobüsü sahneden sil
            }
        }
    }
}
