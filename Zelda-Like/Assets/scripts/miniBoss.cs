using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBoss : MonoBehaviour
{
    [SerializeField]
    private int health = 12;
    public Animator bossAnimator;
    public Animator animator;

    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;

    bool done = false;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "attack")
        {
            if(health > 0)
            {
                health--;
            }
            else if(health <= 0)
            {
                bossAnimator.SetBool("start", false);
                bossAnimator.SetBool("dead", true);

                animator.SetBool("close", false);
                animator.SetBool("open", true);
                if(done == false)
                {
                    puzz.rooms[roomNum]++;
                    done = true;
                }
            }
        }
    }
}
