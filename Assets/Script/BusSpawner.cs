using UnityEngine;

public class BusSpawner : MonoBehaviour
{
    public GameObject busPrefab;
    public static BusSpawner Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SpawnBus(); // Ýlk otobüsü baþlat
    }

    public void SpawnBus()
    {
        Instantiate(busPrefab, busPrefab.GetComponent<BusMovement>().startPosition, Quaternion.identity);
    }
}
