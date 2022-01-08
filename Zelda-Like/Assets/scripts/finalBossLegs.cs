using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class finalBossLegs : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private GameObject[] legs;
    bool[] passed = { false, false, false, false, false, false, false, false };
    public int legCount;
    bool coolDown = false;
    [SerializeField] private GameObject bossEye;
    [SerializeField] private GameObject stunCollider;
    [SerializeField] private GameObject bossBody;

    void Start()
    {
        Array.Clear(passed, 0, passed.Length);
        bossEye.SetActive(false);
    }

    void Update()
    {
        for(int i = 0; i < legs.Length; i++)
        {
            if(legs[i].activeSelf == false && passed[i] == false)
            {
                Debug.Log("passed for - if");
                legCount++;
                passed[i] = true;
            }
        }
        if(legCount >= 8 && coolDown == false)
        {
            StartCoroutine(stunned());
        }
    }

    IEnumerator stunned()
    {
        coolDown = true;
        animator.speed = 0;
        bossEye.GetComponent<Collider2D>().enabled = true;
        bossBody.GetComponent<Collider2D>().enabled = false;
        stunCollider.SetActive(true);
        bossEye.SetActive(true);
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < legs.Length; i++)
        {
            legs[i].SetActive(true);
        }
        bossEye.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(.4f);
        bossBody.GetComponent<Collider2D>().enabled = true;
        stunCollider.SetActive(false);
        bossEye.SetActive(false);
        Array.Clear(passed, 0, passed.Length);
        legCount = 0;
        animator.speed = 1;
        coolDown = false;
    }
}
