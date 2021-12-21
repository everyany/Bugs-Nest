using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noGrab : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;
    [SerializeField]
    private GameObject player;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            stats.noGrab = false;
            Physics2D.IgnoreLayerCollision(3, 12, false);
        }
    }
}
