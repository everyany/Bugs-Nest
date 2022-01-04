using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pit : MonoBehaviour
{
    public Transform teleportTarget;
    [SerializeField] private GameObject player;
    [SerializeField]
    private playerStats stats;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = teleportTarget.transform.position;
            if (stats.hit == false && stats.health > 0)
            {
                stats.health--;
                stats.hit = true;
            }
        }
    }
}
