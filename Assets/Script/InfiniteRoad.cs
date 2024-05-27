using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public GameObject roadPrefab; // Yol par�as� prefab�
    public Transform player; // Oyuncunun transformu
    public float roadLength = 10f; // Yol par�as�n�n uzunlu�u
    public int maxRoadPieces = 20; // Maksimum yol par�a say�s�
    public float pieceOffset = 5f; // Yol par�alar� aras�ndaki mesafe

    private List<GameObject> roadPieces = new List<GameObject>(); // Olu�turulan yol par�alar�n� tutacak liste
    private Vector3 spawnPosition = Vector3.zero; // Yeni yol par�as�n�n do�aca�� konum

    void Start()
    {
        // �lk yol par�alar�n� olu�tur
        for (int i = 0; i < maxRoadPieces; i++)
        {
            SpawnRoadPiece();
        }
    }

    void Update()
    {
        // Oyuncu ilerledik�e yeni yol par�alar� olu�tur
        if (player.position.z > spawnPosition.z - roadLength)
        {
            SpawnRoadPiece();
            RemoveRoadPiece();
        }
    }

    // Yeni yol par�as� olu�tur
    void SpawnRoadPiece()
    {
        GameObject newRoadPiece = Instantiate(roadPrefab, spawnPosition, Quaternion.identity);
        roadPieces.Add(newRoadPiece);

        // Yeni yol par�as�n�n konumunu g�ncelle
        spawnPosition.z += roadLength + pieceOffset;
    }

    // Eski yol par�as�n� kald�r
    void RemoveRoadPiece()
    {
        Destroy(roadPieces[0]);
        roadPieces.RemoveAt(0);
    }
}
