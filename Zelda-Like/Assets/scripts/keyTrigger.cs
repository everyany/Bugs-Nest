using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyTrigger : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKey(KeyCode.Z))
        {
            Destroy(this.gameObject);
            stats.keys = stats.keys + 1f;
        }
    }
}
