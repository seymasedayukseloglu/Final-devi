using UnityEngine;
using UnityEngine.UI;

public class SeaShell : MonoBehaviour
{
    public GameObject rotatingObject; // D�nen nesne
    public float rotationSpeed = 50f; // D�nme h�z�
    public float displayTime = 3f; // Nesnenin ekranda kalaca�� s�re
    public Button startButton; // Buton referans�

    private bool rotationStarted = false; // D�nme ba�lad� m�?
    private float timer = 0f; // Timer

    void Update()
    {
        // E�er d�nme ba�lad�ysa, nesneyi s�rekli olarak d�nd�r
        if (rotationStarted)
        {
            rotatingObject.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            // E�er timer displayTime s�resinden fazla ise d�nme i�lemini durdur ve nesneyi yok et
            if (timer >= displayTime)
            {
                rotationStarted = false; // D�nme durduruldu
                Destroy(rotatingObject); // Nesneyi yok et
            }
            else
            {
                // Timer'� g�ncelle
                timer += Time.deltaTime;
            }
        }
    }

    void Start()
    {
        // Ba�la butonuna t�klanma event'ini StartRotationOnClick metoduna ba�l�yoruz
        startButton.onClick.AddListener(StartRotationOnClick);
    }

    // Ba�la butonuna bas�ld���nda bu metod �a�r�lacak
    public void StartRotationOnClick()
    {
        rotationStarted = true; // D�nme ba�lad�
    }
}
