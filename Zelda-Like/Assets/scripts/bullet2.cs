using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "lava" || collision.gameObject.tag == "crystal")
        {
            Destroy(this.gameObject);
        }
    }
}