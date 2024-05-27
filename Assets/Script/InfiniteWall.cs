using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteWall : MonoBehaviour
{
    public GameObject wallPrefab; // Duvar par�as� prefab�
    public Transform player; // Oyuncunun transformu
    public float wallLength = 10f; // Duvar par�as�n�n uzunlu�u
    public int maxWallPieces = 20; // Maksimum duvar par�a say�s�
    public float pieceOffset = 5f; // Duvar par�alar� aras�ndaki mesafe

    private List<GameObject> wallPieces = new List<GameObject>(); // Olu�turulan duvar par�alar�n� tutacak liste
    private float spawnZ = 0; // Yeni duvar par�as�n�n do�aca�� Z konumu

    void Start()
    {
        // �lk duvar par�as�n�n pozisyonunu al
        spawnZ = transform.position.z;

        // �lk duvar par�alar�n� olu�tur
        for (int i = 0; i < maxWallPieces; i++)
        {
            SpawnWallPiece();
        }
    }

    void Update()
    {
        // Oyuncu ilerledik�e yeni duvar par�alar� olu�tur
        if (player.position.z > spawnZ - wallLength * maxWallPieces)
        {
            SpawnWallPiece();
            RemoveWallPiece();
        }
    }

    // Yeni duvar par�as� olu�tur
    void SpawnWallPiece()
    {
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, spawnZ);
        GameObject newWallPiece = Instantiate(wallPrefab, spawnPosition, Quaternion.identity);
        wallPieces.Add(newWallPiece);

        // Yeni duvar par�as�n�n Z konumunu g�ncelle
        spawnZ -= wallLength + pieceOffset;
    }

    // Eski duvar par�as�n� kald�r
    void RemoveWallPiece()
    {
        Destroy(wallPieces[0]);
        wallPieces.RemoveAt(0);
    }
}
