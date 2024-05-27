using UnityEngine;

public class OyuncuKonumSaklayıcı : MonoBehaviour
{
    public static OyuncuKonumSaklayıcı instance;

    // İlk sahnede oyuncunun konumunu ve rotasyonunu kaydetmek için kullanılacak değişkenler
    public Vector3 oyuncuKonumu;
    public Quaternion oyuncuRotasyonu;

    void Awake()
    {
        // Singleton örneğini ayarla
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}