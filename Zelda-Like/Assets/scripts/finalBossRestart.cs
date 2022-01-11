using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBossRestart : MonoBehaviour
{
    public Animator bossAnimator;
    [SerializeField] private GameObject bossTrigger;
    [SerializeField]
    private playerStats stats;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            bossTrigger.SetActive(true);
            stats.finalBossStart = false;
        }
    }
}
