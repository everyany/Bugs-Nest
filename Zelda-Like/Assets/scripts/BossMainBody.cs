using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMainBody : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player" && stats.hit != true)
        {
            stats.hit = true;
            stats.health--;
        }
    }
}
