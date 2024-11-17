using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class BallController : NetworkBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            NetworkObject playerNetworkObject = collision.gameObject.GetComponent<NetworkObject>();
            if (playerNetworkObject != null)
            {
                NetworkObject.ChangeOwnership(playerNetworkObject.OwnerClientId);
            }
        }
    }
}
