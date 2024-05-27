using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Karakterin hareket hýzý
    public float rotationSpeed = 300f;  // Karakterin dönüþ hýzý

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Rotate();
        Move();
    }

    void Rotate()
    {
        // Sað ve sol tuþlarý ile dönüþ girdileri alýnýyor
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        // Karakterin dönüþü
        Vector3 rotationVector = new Vector3(0, rotation, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationVector));
    }

    void Move()
    {
        // Ýleri ve geri tuþlarý ile hareket girdileri alýnýyor
        float moveVertical = Input.GetAxis("Vertical");

        // Karakterin hareket ettirilmesi
        Vector3 movement = transform.forward * moveVertical * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}