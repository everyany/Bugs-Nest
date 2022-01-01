using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class elasticFly : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private playerStats stats;
    public Animator animator;
    bool coolDown = false;


    void Start()
    {
        Physics2D.IgnoreLayerCollision(12, 14, true);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && stats.grabbedStatusEffect == false && stats.noGrab == false)
        {
            stats.speedStatusEffect = true;
            stats.speed = 0f;
            player.transform.parent = this.gameObject.transform;
            stats.grabbedStatusEffect = true;
            player.transform.rotation = Quaternion.identity;
            Physics2D.IgnoreLayerCollision(3, 9, true);
            Physics2D.IgnoreLayerCollision(9, 12, true);
            Physics2D.IgnoreLayerCollision(3, 14, true);
            if(coolDown == false)
            {
                StartCoroutine(wait());
            }
        }

        if (collider.gameObject.tag == "flammable")
        {
            Physics2D.IgnoreLayerCollision(3, 12, true);
        }
    }

    IEnumerator wait()
    {
        coolDown = true;
        animator.SetBool("flying", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("flying", false);
        coolDown = false;
    }
}