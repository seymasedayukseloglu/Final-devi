using UnityEngine;
using UnityEngine.UI;

public class SeaShell : MonoBehaviour
{
    public GameObject rotatingObject; // Dönen nesne
    public float rotationSpeed = 50f; // Dönme hýzý
    public float displayTime = 3f; // Nesnenin ekranda kalacaðý süre
    public Button startButton; // Buton referansý

    private bool rotationStarted = false; // Dönme baþladý mý?
    private float timer = 0f; // Timer

    void Update()
    {
        // Eðer dönme baþladýysa, nesneyi sürekli olarak döndür
        if (rotationStarted)
        {
            rotatingObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            // Eðer timer displayTime süresinden fazla ise dönme iþlemini durdur ve nesneyi yok et
            if (timer >= displayTime)
            {
                rotationStarted = false; // Dönme durduruldu
                Destroy(rotatingObject); // Nesneyi yok et
            }
            else
            {
                // Timer'ý güncelle
                timer += Time.deltaTime;
            }
        }
    }

    void Start()
    {
        // Baþla butonuna týklanma event'ini StartRotationOnClick metoduna baðlýyoruz
        startButton.onClick.AddListener(StartRotationOnClick);
    }

    // Baþla butonuna basýldýðýnda bu metod çaðrýlacak
    public void StartRotationOnClick()
    {
        rotationStarted = true; // Dönme baþladý
    }
}
