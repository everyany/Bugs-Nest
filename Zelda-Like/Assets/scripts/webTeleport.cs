using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webTeleport : MonoBehaviour
{
    public Transform teleportTarget;
    public Rigidbody2D rb;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "flammable" || collision.gameObject.tag == "spider")
        {
            collision.gameObject.transform.position = teleportTarget.transform.position;
            rb.velocity = Vector3.zero;
        }
    }
}