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
        isMoving = true; // Otob�s sahneye geldi�inde hemen hareket etmeye ba�lar
    }

    void Update()
    {
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, endPosition, step);

            if (transform.position == endPosition)
            {
                isMoving = false; // Hedef pozisyona ula�t���nda hareketi durdur
                // Yeni otob�s olu�tur
                BusSpawner.Instance.SpawnBus();
                Destroy(gameObject); // Mevcut otob�s� sahneden sil
            }
        }
    }
}
