using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBossTrigger : MonoBehaviour
{
    //public Animator animator;
    public Animator bossAnimator;
    [SerializeField]
    private playerStats stats;

    void Start()
    {
        stats.finalBossStart = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            bossAnimator.SetBool("start", true);
            stats.fbTempHealth = stats.finalBossHealth;
            this.gameObject.SetActive(false);
            stats.finalBossStart = true;
        }
    }
}
