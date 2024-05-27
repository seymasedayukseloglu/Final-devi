using TMPro;
using UnityEngine;

public class CubeText : MonoBehaviour
{
    public int numberOfCubes = 5; // Olu�turulacak k�p say�s�
    public Vector3 startPosition = new Vector3(0, 0, 0); // Ba�lang�� pozisyonu
    public Vector3 offset = new Vector3(2, 0, 0); // K�pler aras� mesafe
    public GameObject cubePrefab; // Prefab referans�

    void Start()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            // Prefab'dan k�p nesnesi olu�turun
            GameObject cube = Instantiate(cubePrefab, startPosition + i * offset, Quaternion.identity);
            cube.name = "TextCube" + i;

            // TextMeshPro bile�enini bulun
            TextMeshPro textMeshPro = cube.GetComponentInChildren<TextMeshPro>();

            // TextMeshPro �zelliklerini ayarlay�n
            if (textMeshPro != null)
            {
                textMeshPro.text = "K�p " + (i + 1);
                textMeshPro.fontSize = 4;
                textMeshPro.alignment = TextAlignmentOptions.Center;
                textMeshPro.enableAutoSizing = true;
            }
        }
    }
}
