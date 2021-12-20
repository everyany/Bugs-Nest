using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class web : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = .5f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            stats.speedStatusEffect = true;
            stats.speed = speed;
            if(collider.gameObject.transform.parent == null)
            {
                player.transform.parent = this.gameObject.transform;
            }
            stats.grabbedStatusEffect = true;
            player.transform.rotation = Quaternion.identity;
            Physics2D.IgnoreLayerCollision(3, 9, true);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
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
