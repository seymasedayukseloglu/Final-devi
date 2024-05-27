using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseDetector : MonoBehaviour
{
    public ScoreTimeHesaplama1 scoreTimeHesaplama1; // Reference to the ScoreTimeHesaplama script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cevap"))
        {
            Debug.Log("Cevap tag'ine sahip nesnenin içinden geçildi!");
            scoreTimeHesaplama1.IncreaseScore();
        }
    }
}