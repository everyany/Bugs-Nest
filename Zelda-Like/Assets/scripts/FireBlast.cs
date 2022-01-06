using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBlast : MonoBehaviour
{
    [SerializeField]
    private GameObject fire1;
    [SerializeField]
    private GameObject fire2;
    [SerializeField]
    private GameObject fire3;
    [SerializeField]
    private GameObject fire4;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private bool shoot;
    private int ammo = 1;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(18, 18, true);
        Physics2D.IgnoreLayerCollision(9, 18, true);
    }

    void Update()
    {
        if(shoot == false)
        {
            ammo = 1;
        }
        if (shoot == true && ammo > 0)
        {
            Instantiate(fire1, firePoint.position, firePoint.rotation);
            Instantiate(fire2, firePoint.position, firePoint.rotation);
            Instantiate(fire3, firePoint.position, firePoint.rotation);
            Instantiate(fire4, firePoint.position, firePoint.rotation);
            ammo--;
            shoot = false;
        }
    }
}
