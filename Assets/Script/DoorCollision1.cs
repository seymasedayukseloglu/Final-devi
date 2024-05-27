
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCollision1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        // Ýstediðiniz sahne adýný buraya yazýn
        string targetSceneName = "SceneHesaplama";

        // Sahneyi deðiþtir
        SceneManager.LoadScene(targetSceneName);
    }
}
