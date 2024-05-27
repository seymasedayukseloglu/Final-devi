using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Karakterin hareket h�z�
    public float rotationSpeed = 300f;  // Karakterin d�n�� h�z�

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
        // Sa� ve sol tu�lar� ile d�n�� girdileri al�n�yor
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

        // Karakterin d�n���
        Vector3 rotationVector = new Vector3(0, rotation, 0);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationVector));
    }

    void Move()
    {
        // �leri ve geri tu�lar� ile hareket girdileri al�n�yor
        float moveVertical = Input.GetAxis("Vertical");

        // Karakterin hareket ettirilmesi
        Vector3 movement = transform.forward * moveVertical * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }
}