using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    [SerializeField]
    private Transform enemy;
    [SerializeField]
    private Transform key;

    void Start()
    {
        Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(key.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
