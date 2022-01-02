using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossRestart : MonoBehaviour
{
    public Animator animator;
    public Animator bossAnimator;
    [SerializeField] private GameObject bossTrigger;
    [SerializeField]
    private playerStats stats;

    void Update()
    {
        if (stats.bossStart)
        {
            animator.SetBool("open", false);
            animator.SetBool("close", true);
        }
        else if(stats.bossStart == false)
        {
            animator.SetBool("open", true);
            animator.SetBool("close", false);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            bossTrigger.SetActive(true);
            stats.bossStart = false;
        }
    }
}
