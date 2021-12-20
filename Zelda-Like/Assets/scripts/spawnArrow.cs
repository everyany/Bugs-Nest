using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnArrow : MonoBehaviour
{
    [SerializeField]
    private Transform hole;
    [SerializeField]
    private GameObject arrow;

    private bool wait = false;

    // Update is called once per frame
    void Update()
    {
        if(wait == false)
        {
            StartCoroutine(spawn());
        }
    }

    IEnumerator spawn()
    {
        Instantiate(arrow, hole.position, hole.rotation);
        wait = true;
        yield return new WaitForSeconds(2.0f);
        wait = false;

    }
}
