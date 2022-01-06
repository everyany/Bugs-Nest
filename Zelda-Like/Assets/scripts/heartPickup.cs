using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartPickup : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKey(KeyCode.Z))
        {
            Destroy(this.gameObject);
            stats.health = stats.healthHolder;
            stats.health++;
            stats.healthHolder++;
        }
    }
}
