using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteWall : MonoBehaviour
{
    public GameObject wallPrefab; // Duvar parçasý prefabý
    public Transform player; // Oyuncunun transformu
    public float wallLength = 10f; // Duvar parçasýnýn uzunluðu
    public int maxWallPieces = 20; // Maksimum duvar parça sayýsý
    public float pieceOffset = 5f; // Duvar parçalarý arasýndaki mesafe

    private List<GameObject> wallPieces = new List<GameObject>(); // Oluþturulan duvar parçalarýný tutacak liste
    private float spawnZ = 0; // Yeni duvar parçasýnýn doðacaðý Z konumu

    void Start()
    {
        // Ýlk duvar parçasýnýn pozisyonunu al
        spawnZ = transform.position.z;

        // Ýlk duvar parçalarýný oluþtur
        for (int i = 0; i < maxWallPieces; i++)
        {
            SpawnWallPiece();
        }
    }

    void Update()
    {
        // Oyuncu ilerledikçe yeni duvar parçalarý oluþtur
        if (player.position.z > spawnZ - wallLength * maxWallPieces)
        {
            SpawnWallPiece();
            RemoveWallPiece();
        }
    }

    // Yeni duvar parçasý oluþtur
    void SpawnWallPiece()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, spawnZ);
        GameObject newWallPiece = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
        wallPieces.Add(newWallPiece);

        // Yeni duvar parçasýnýn Z konumunu güncelle
        spawnZ -= wallLength + pieceOffset;
    }

    // Eski duvar parçasýný kaldýr
    void RemoveWallPiece()
    {
        Destroy(wallPieces[0]);
        wallPieces.RemoveAt(0);
    }
}
