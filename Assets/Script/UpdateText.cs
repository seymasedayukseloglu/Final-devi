using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public TextMeshPro textMeshPro;

    void Start()
    {
        // Ba�lang��ta bir metin atamas� yap�n
        textMeshPro.text = "Ba�lang�� Metni";
    }

    void Update()
    {
        // �rne�in her frame'de metni g�ncelleyebilirsiniz
        if (Input.GetKeyDown(KeyCode.Space))
        {
            textMeshPro.text = "Yeni Metin";
        }
    }
}
