using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && (gameObject.CompareTag("Cevap") || gameObject.CompareTag("Cube")))
        {
            Debug.Log("Çarptý!");
        }
    }
}

public class Example : MonoBehaviour
{
    void Start()
    {
        // CollisionLogger adýnda bir GameObject oluþtur
        GameObject collisionLoggerObject = new GameObject("CollisionLogger");

        // CollisionLogger GameObject'ine CollisionLogger scriptini ekleyin
        collisionLoggerObject.AddComponent<CollisionLogger>();
    }
}
