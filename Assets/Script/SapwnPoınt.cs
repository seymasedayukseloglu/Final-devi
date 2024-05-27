using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoınt : MonoBehaviour
{
    // Karakterin doğması gereken prefab
    public GameObject playerPrefab;

    void Start()
    {
        SpawnPlayer();
    }

    // Karakteri spawn noktasında doğur
    void SpawnPlayer()
    {
        // spawn noktasının konumu
        Vector3 spawnPosition = transform.position;

        // spawn noktasının yönelimi
        Quaternion spawnRotation = transform.rotation;

        // Eğer oyuncu daha önce oluşturulmuşsa sil
        GameObject existingPlayer = GameObject.FindGameObjectWithTag("Player");
        if (existingPlayer != null)
        {
            Destroy(existingPlayer);
        }

        // Karakteri doğur
        GameObject player = Instantiate(playerPrefab, spawnPosition, spawnRotation);

        // Eğer karakter prefab'ı içinde "PlayerController" bileşeni varsa, bu bileşeni etkinleştir
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.enabled = true;
        }
        else
        {
            Debug.LogWarning("PlayerController bileşeni bulunamadı. Karakter kontrolü yapılandırılamadı.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Oyuncu spawn noktasına ulaştığında, sahne değiştirme işlemini gerçekleştir
            SceneManager.LoadScene("SceneGırıs");
        }
    }

    void OnEnable()
    {
        // "SceneGırıs" sahnesine her girildiğinde karakteri spawn et
        SceneManager.sceneLoaded += SahneYuklendiginde;
    }

    void OnDisable()
    {
        // Script devre dışı bırakıldığında olay aboneliğini kaldır
        SceneManager.sceneLoaded -= SahneYuklendiginde;
    }

    void SahneYuklendiginde(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SceneGırıs")
        {
            SpawnPlayer();
        }
    }
}
