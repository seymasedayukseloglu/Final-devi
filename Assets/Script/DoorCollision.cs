using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") // Oyuncu ile �arp��ma kontrol�
        {
            ChangeScene(); // Sahneyi de�i�tir
        }
    }

    private void ChangeScene()
    {
        // �stedi�iniz sahne ad�n� buraya yaz�n
        string targetSceneName = "SceneKart";

        // Sahneyi de�i�tir
        SceneManager.LoadScene(targetSceneName);
    }
}
