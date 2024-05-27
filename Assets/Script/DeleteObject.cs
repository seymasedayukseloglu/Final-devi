using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    void Start()
    {
        // "door1" etiketine sahip nesneyi bul ve sil
        GameObject door = GameObject.FindGameObjectWithTag("door1");
        if (door != null)
        {
            Destroy(door);
        }
        else
        {
            Debug.LogWarning("door1 etiketine sahip nesne bulunamadý!");
        }
    }
}
