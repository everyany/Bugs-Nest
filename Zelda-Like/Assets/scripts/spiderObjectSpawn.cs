using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderObjectSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject webb;
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Transform firePoint;

    private bool coolDown = false;
    private bool coolDown2 = false;

    [SerializeField]
    private playerStats stats;

    void Update()
    {
        if(stats.finalBossStart == true)
        {
            if (coolDown == false)
            {
                StartCoroutine(web());
            }
            if (coolDown2 == false)
            {
                StartCoroutine(monster());
            }
        }
    }

    IEnumerator web()
    {
        coolDown = true;
        Instantiate(webb, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(.2f);
        coolDown = false;
    }

    IEnumerator monster()
    {
        coolDown2 = true;
        Instantiate(enemy, firePoint.position, firePoint.rotation);
        Instantiate(enemy, firePoint.position, firePoint.rotation);
        Instantiate(enemy, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(15f);
        coolDown2 = false;
    }
}
