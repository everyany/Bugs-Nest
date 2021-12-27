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

    public bool coolDown = false;

    public SpriteRenderer m_SpriteRenderer;
    Color32 hit = new Color32(255, 0, 255, 255);
    Color32 normal = new Color32(255, 255, 255, 255);

    void Start()
    {
        Array.Clear(enemies.enemies, 0, enemies.enemies.Length);
        Physics2D.IgnoreLayerCollision(10, 16, true);
        Physics2D.IgnoreLayerCollision(10, 17, true);
    }

    void Update()
    {
        if (health <= 0 && dead == false)
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
        if (collision.gameObject.tag == "sword" && health > -1)
        {
            health -= 2;
            rb.velocity = Vector3.zero;
            if (coolDown == false)
            {
                StartCoroutine(colorChange());
            }
        }
        else if (collision.gameObject.tag == "bullet" && health > -1)
        {
            health--;
            rb.velocity = Vector3.zero;
            if (coolDown == false)
            {
                StartCoroutine(colorChange());
            }
        }
    }

    IEnumerator colorChange()
    {
        coolDown = true;
        m_SpriteRenderer.color = hit;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = normal;
        coolDown = false;
    }
}
