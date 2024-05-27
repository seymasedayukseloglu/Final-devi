using UnityEngine;
using UnityEngine.UI;

public class GameEndPanel : MonoBehaviour
{
    public Text endGameText; // Oyun sonu metnini g�sterecek metin alan�

    // Oyun sonu metnini ekranda g�steren fonksiyon
    public void ShowEndGameText(float totalTime, int[] scores)
    {
        // Oyun sonu metnini olu�tur
        string endText = "Oyun Bitti!\n\n";
        endText += "Toplam Oyun S�resi: " + Mathf.Floor(totalTime / 60f).ToString("00") + " dakika " + Mathf.Floor(totalTime % 60f).ToString("00") + " saniye\n\n";
        endText += "Mini Oyun Skorlar�:\n";
        endText += "Kart Oyunu: " + scores[0].ToString() + " puan\n";
        endText += "Hesaplama Oyunu: " + scores[1].ToString() + " puan\n";
        endText += "Lumis'in Yolculu�u: " + scores[2].ToString() + " puan\n\n";
        endText += "Harika bir i� ��kard�n�z! Tekrar oynamak isterseniz buyurun, labirent daima a��kt�r! ??????";

        // Metin alan�na metni g�ster
        endGameText.text = endText;
    }
}
