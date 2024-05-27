using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCollision2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        // Hedef sahnenin adýný buraya yazýn
        string targetSceneName = "SceneDikkat";

        // Sahneyi deðiþtir
        SceneManager.LoadScene(targetSceneName);
    }
}
