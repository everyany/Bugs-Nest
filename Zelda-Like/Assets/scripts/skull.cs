using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class skull : MonoBehaviour
{
    [SerializeField]
    private int roomNum;
    [SerializeField]
    private Room7Enemies enemies;

    [SerializeField]
    public int health = 5;

    private bool dead = false;

    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        Array.Clear(enemies.enemies, 0, enemies.enemies.Length);
    }

    void Update()
    {
        if (health == 0 && dead == false)
        {
            if(roomNum != 0)
            {
                enemies.enemies[roomNum]++;
            }
            dead = true;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "attack" && health > -1)
        {
            health--;
            rb.velocity = Vector3.zero;
        }
    }
}
