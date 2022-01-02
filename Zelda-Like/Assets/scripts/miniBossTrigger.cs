using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBossTrigger : MonoBehaviour
{
    public Animator animator;
    public Animator bossAnimator;
    [SerializeField]
    private playerStats stats;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            bossAnimator.SetBool("start", true);
            this.gameObject.SetActive(false);
            stats.bossStart = true;
        }
    }
}
