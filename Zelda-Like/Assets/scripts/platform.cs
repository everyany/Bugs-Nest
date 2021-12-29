using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject web;
    [SerializeField]
    private GameObject circle;
    [SerializeField]
    private GameObject frontOfPlayer;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (collider.gameObject.transform.parent == null && collider.gameObject.tag == "Player")
            {
                player.transform.parent = web.transform;
                player.transform.localPosition = new Vector3(0, 0, 0);
                circle.transform.localPosition = new Vector3(0, 0, 0);
                frontOfPlayer.transform.localPosition = new Vector3(0.1999898f, -16f, 0.0f);
            }
            stats.grabbedStatusEffect = true;
            player.transform.rotation = Quaternion.identity;
            Physics2D.IgnoreLayerCollision(3, 9, true);
            Physics2D.IgnoreLayerCollision(3, 10, true);
            Physics2D.IgnoreLayerCollision(3, 13, true);
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //collider.gameObject.transform.parent = null;
            player.transform.rotation = Quaternion.identity;
            stats.grabbedStatusEffect = false;
            circle.transform.localPosition = new Vector3(0, 0, 0);
            frontOfPlayer.transform.localPosition = new Vector3(0.1999898f, -16f, 0.0f);
        }
    }
}