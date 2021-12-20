using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopTrigger : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;
    [SerializeField]
    private GameObject player;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            stats.speedStatusEffect = false;
            player.transform.parent = null;
            player.transform.rotation = Quaternion.identity;
            stats.grabbedStatusEffect = false;
        }
    }
}
