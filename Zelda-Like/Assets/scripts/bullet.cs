using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private playerStats stats;

    bool coolDown = false;
    bool usable;


    void Update()
    {
        for(int i = 0; i < stats.skillUse.Length; i++)
        {
            if (stats.skillUse[i])
            {
                usable = false;
            }
            else
            {
                usable = true;
            }
        }

        if (Input.GetKey(KeyCode.C) && coolDown == false || Input.GetButton("Fire2") && coolDown == false && usable)
        {
            StartCoroutine(projectile());
        }
    }

    IEnumerator projectile()
    {
        coolDown = true;
        stats.skillUse[2] = true;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(.6f);
        stats.skillUse[2] = false;
        coolDown = false;
    }
}
