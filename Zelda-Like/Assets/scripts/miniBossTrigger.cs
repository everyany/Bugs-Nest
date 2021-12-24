using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBossTrigger : MonoBehaviour
{
    public Animator animator;
    public Animator bossAnimator;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            animator.SetBool("close", true);
            bossAnimator.SetBool("start", true);
            Destroy(this.gameObject);
        }
    }
}
