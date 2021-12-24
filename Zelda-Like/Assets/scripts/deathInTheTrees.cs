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
            StartCoroutine(dramaticEffect());
        }
    }

    IEnumerator dramaticEffect()
    {
        yield return new WaitForSeconds(.19f);
        player.transform.parent = null;
        player.transform.position = teleportTarget.transform.position;
    }
}
