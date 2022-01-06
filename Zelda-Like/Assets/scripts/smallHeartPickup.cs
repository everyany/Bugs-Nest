using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallHeartPickup : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;

    void Update()
    {
        StartCoroutine(heartTimeout());
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            if(stats.health < stats.healthHolder)
            {
                stats.health++;
            }
        }
    }

    IEnumerator heartTimeout()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}
