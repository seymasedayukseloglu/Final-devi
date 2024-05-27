using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteRoad : MonoBehaviour
{
    public GameObject roadPrefab; // Yol parçasý prefabý
    public Transform player; // Oyuncunun transformu
    public float roadLength = 10f; // Yol parçasýnýn uzunluðu
    public int maxRoadPieces = 20; // Maksimum yol parça sayýsý
    public float pieceOffset = 5f; // Yol parçalarý arasýndaki mesafe

    private List<GameObject> roadPieces = new List<GameObject>(); // Oluþturulan yol parçalarýný tutacak liste
    private Vector3 spawnPosition = Vector3.zero; // Yeni yol parçasýnýn doðacaðý konum

    void Start()
    {
        // Ýlk yol parçalarýný oluþtur
        for (int i = 0; i < maxRoadPieces; i++)
        {
            SpawnRoadPiece();
        }
    }

    void Update()
    {
        // Oyuncu ilerledikçe yeni yol parçalarý oluþtur
        if (player.position.z > spawnPosition.z - roadLength)
        {
            SpawnRoadPiece();
            RemoveRoadPiece();
        }
    }

    // Yeni yol parçasý oluþtur
    void SpawnRoadPiece()
    {
        GameObject newRoadPiece = Instantiate(roadPrefab, spawnPosition, Quaternion.identity);
        roadPieces.Add(newRoadPiece);

        // Yeni yol parçasýnýn konumunu güncelle
        spawnPosition.z += roadLength + pieceOffset;
    }

    // Eski yol parçasýný kaldýr
    void RemoveRoadPiece()
    {
        Destroy(roadPieces[0]);
        roadPieces.RemoveAt(0);
    }
}
