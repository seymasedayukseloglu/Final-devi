using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") // Oyuncu ile çarpýþma kontrolü
        {
            ChangeScene(); // Sahneyi deðiþtir
        }
    }

    private void ChangeScene()
    {
        // Ýstediðiniz sahne adýný buraya yazýn
        string targetSceneName = "SceneKart";

        // Sahneyi deðiþtir
        SceneManager.LoadScene(targetSceneName);
    }
}
