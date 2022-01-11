using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossBarrier : MonoBehaviour
{
    [SerializeField]
    private GameObject barrier;

    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            barrier.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        barrier.SetActive(false);
    }
}
