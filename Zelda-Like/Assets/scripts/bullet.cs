using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;

    bool coolDown = false;


    void Update()
    {
        if (Input.GetKey(KeyCode.C) && coolDown == false || Input.GetButton("Fire2") && coolDown == false)
        {
            StartCoroutine(projectile());
        }
    }

    IEnumerator projectile()
    {
        coolDown = true;
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(.5f);
        coolDown = false;
    }
}
