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
        // Hedef sahnenin ad�n� buraya yaz�n
        string targetSceneName = "SceneDikkat";

        // Sahneyi de�i�tir
        SceneManager.LoadScene(targetSceneName);
    }
}
