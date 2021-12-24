using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeFirefly : MonoBehaviour
{
    public Animator animator;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "bullet")
        {
            animator.SetBool("drop", true);
            Destroy(this.gameObject);
        }
    }
}
