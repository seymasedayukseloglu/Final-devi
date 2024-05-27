using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public TextMeshPro textMeshPro;

    void Start()
    {
        // Baþlangýçta bir metin atamasý yapýn
        textMeshPro.text = "Baþlangýç Metni";
    }

    void Update()
    {
        // Örneðin her frame'de metni güncelleyebilirsiniz
        if (Input.GetKeyDown(KeyCode.Space))
        {
            textMeshPro.text = "Yeni Metin";
        }
    }
}
