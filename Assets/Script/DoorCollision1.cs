
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
        // �stedi�iniz sahne ad�n� buraya yaz�n
        string targetSceneName = "SceneHesaplama";

        // Sahneyi de�i�tir
        SceneManager.LoadScene(targetSceneName);
    }
}
