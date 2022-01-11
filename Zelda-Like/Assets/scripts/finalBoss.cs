using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBoss : MonoBehaviour
{
    [SerializeField]
    private GameObject finalBossHolder;
    [SerializeField]
    private Transform heartPoint;
    public Animator bossAnimator;
    //public Animator animator;

    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;

    bool done = false;
    public bool coolDown = false;

    public SpriteRenderer m_SpriteRenderer;
    Color32 hit = new Color32(255, 0, 255, 255);
    Color32 normal = new Color32(255, 255, 255, 255);

    [SerializeField]
    private playerStats stats;

    bool heart = false;
    [SerializeField]
    private GameObject heartFab;
    [SerializeField]
    private GameObject BossRestart;

    void Update()
    {
        //health = stats.fbTempHealth;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "attack" || coll.gameObject.tag == "sword")
        {
            coolDown = false;
            if (stats.fbTempHealth > 0)
            {
                stats.fbTempHealth -= 2;
            }
            else if (stats.fbTempHealth <= 0)
            {
                bossAnimator.SetBool("start", false);
                bossAnimator.SetBool("dead", true);
                if (heart == false)
                {
                    heart = true;
                    Instantiate(heartFab, heartPoint.position, heartPoint.rotation);
                }
                Destroy(finalBossHolder);
                Destroy(BossRestart);
                //animator.SetBool("close", false);
                //animator.SetBool("open", true);
                if (done == false)
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
        else if (coll.gameObject.tag == "bullet")
        {
            coolDown = false;
            if (stats.fbTempHealth > 0)
            {
                stats.fbTempHealth--;
            }
            else if (stats.fbTempHealth <= 0)
            {
                bossAnimator.SetBool("start", false);
                bossAnimator.SetBool("dead", true);
                if (heart == false)
                {
                    heart = true;
                    Instantiate(heartFab, heartPoint.position, heartPoint.rotation);
                }
                Destroy(finalBossHolder);
                Destroy(BossRestart);

                //animator.SetBool("close", false);
                //animator.SetBool("open", true);
                if (done == false)
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
