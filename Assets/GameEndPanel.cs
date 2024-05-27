using UnityEngine;
using UnityEngine.UI;

public class GameEndPanel : MonoBehaviour
{
    public Text endGameText; // Oyun sonu metnini gösterecek metin alaný

    // Oyun sonu metnini ekranda gösteren fonksiyon
    public void ShowEndGameText(float totalTime, int[] scores)
    {
        // Oyun sonu metnini oluþtur
        string endText = "Oyun Bitti!\n\n";
        endText += "Toplam Oyun Süresi: " + Mathf.Floor(totalTime / 60f).ToString("00") + " dakika " + Mathf.Floor(totalTime % 60f).ToString("00") + " saniye\n\n";
        endText += "Mini Oyun Skorlarý:\n";
        endText += "Kart Oyunu: " + scores[0].ToString() + " puan\n";
        endText += "Hesaplama Oyunu: " + scores[1].ToString() + " puan\n";
        endText += "Lumis'in Yolculuðu: " + scores[2].ToString() + " puan\n\n";
        endText += "Harika bir iþ çýkardýnýz! Tekrar oynamak isterseniz buyurun, labirent daima açýktýr! ??????";

        // Metin alanýna metni göster
        endGameText.text = endText;
    }
}
