using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webSpawn : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject web;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            stats.speedStatusEffect = true;
            stats.speed = 0f;
          /*if (collider.gameObject.transform.parent == null && collider.gameObject.tag == "Player")
            {
                player.transform.parent = web.transform;
                player.transform.localPosition = new Vector3(0, 0, 0);
            }*/
            stats.grabbedStatusEffect = true;
            player.transform.parent = web.transform;
            player.transform.localPosition = new Vector3(0, 0, 0);
            player.transform.rotation = Quaternion.identity;
            Physics2D.IgnoreLayerCollision(3, 9, true);
            Physics2D.IgnoreLayerCollision(3, 10, true);
            Physics2D.IgnoreLayerCollision(3, 13, true);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("you've exited");
        if (collider.gameObject.tag == "Player")
        {
            stats.speedStatusEffect = false;
            //collider.gameObject.transform.parent = null;
            player.transform.rotation = Quaternion.identity;
            stats.grabbedStatusEffect = false;
        }
    }
}
