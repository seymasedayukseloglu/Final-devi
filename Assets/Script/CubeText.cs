using TMPro;
using UnityEngine;

public class CubeText : MonoBehaviour
{
    public int numberOfCubes = 5; // Oluþturulacak küp sayýsý
    public Vector3 startPosition = new Vector3(0, 0, 0); // Baþlangýç pozisyonu
    public Vector3 offset = new Vector3(2, 0, 0); // Küpler arasý mesafe
    public GameObject cubePrefab; // Prefab referansý

    void Start()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            // Prefab'dan küp nesnesi oluþturun
            GameObject cube = Instantiate(cubePrefab, startPosition + i * offset, Quaternion.identity);
            cube.name = "TextCube" + i;

            // TextMeshPro bileþenini bulun
            TextMeshPro textMeshPro = cube.GetComponentInChildren<TextMeshPro>();

            // TextMeshPro özelliklerini ayarlayýn
            if (textMeshPro != null)
            {
                textMeshPro.text = "Küp " + (i + 1);
                textMeshPro.fontSize = 4;
                textMeshPro.alignment = TextAlignmentOptions.Center;
                textMeshPro.enableAutoSizing = true;
            }
        }
    }
}
