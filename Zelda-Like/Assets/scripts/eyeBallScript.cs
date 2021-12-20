using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeBallScript : MonoBehaviour
{
    [SerializeField]
    private skullKey skullCount;

    [SerializeField]
    private int health = 30;

    void Start()
    {
        skullCount.eyes = 0;
    }

    void Update()
    {
        if (health == 0)
        {
            skullCount.eyes++;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "attack" && health >= 1)
        {
            health--;
        }
    }
}