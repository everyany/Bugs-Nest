using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathInTheTrees : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Transform teleportTarget;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && stats.grabbedStatusEffect)
        {
            player.transform.parent = null;
            stats.health = 0;
         // player.transform.position = teleportTarget.transform.position;
         // StartCoroutine(dramaticEffect());
        }
    }

  /*IEnumerator dramaticEffect()
    {
      //yield return new WaitForSeconds(.01f);
        player.transform.parent = null;
        player.transform.position = teleportTarget.transform.position;
    }*/
}
