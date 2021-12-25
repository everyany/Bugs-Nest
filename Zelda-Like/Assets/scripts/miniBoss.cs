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
    public bool coolDown = false;

    public SpriteRenderer m_SpriteRenderer;
    Color32 hit = new Color32(255, 0, 255, 255);
    Color32 normal = new Color32(255, 255, 255, 255);

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "attack" || coll.gameObject.tag == "wall" || coll.gameObject.tag == "sword" || coll.gameObject.tag == "bullet")
        {
            coolDown = false;
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
            if (coolDown == false)
            {
                StartCoroutine(colorChange());
            }
        }
    }

    IEnumerator colorChange()
    {
        coolDown = true;
        m_SpriteRenderer.color = hit;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = normal;
        coolDown = false;
    }
}
