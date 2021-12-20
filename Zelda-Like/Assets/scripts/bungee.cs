using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bungee : MonoBehaviour
{
    public Vector2 destination;
    public Vector2 destination2;
    public float speed;
    public Rigidbody2D player;
    public GameObject fly;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "fly")
        {
            player.transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime * speed);
            fly.transform.position = Vector2.Lerp(transform.position, destination2, Time.deltaTime * speed);
        }
    }
}
