using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(NetworkObject))]
public class PlayerMove : NetworkBehaviour
{
    [SerializeField] private float force = 5;
    [SerializeField] private float drag = 0.95f;
    private Vector2 movement;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rb.AddForce(movement);
        rb.velocity *= drag;
    }
    private void Update()
    {
        
        Movement();
    }
    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(x, y);

        if (input.magnitude > 1)
        {
            input.Normalize();
        }
        movement = input * force;
    }

  
}

