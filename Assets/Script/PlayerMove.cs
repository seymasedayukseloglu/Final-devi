using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float baseSpeed = 5; // Sabit hýz
    public Rigidbody rb;

    private float speed; // Gerçek hýz deðeri
    private float horizontalInput;

    private void Start()
    {
        speed = baseSpeed; // Baþlangýçta hýzý sabit hýz olarak ayarla
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    // Update is called once per frame
    void Update()
    {
        // Yatay hareketi al
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
