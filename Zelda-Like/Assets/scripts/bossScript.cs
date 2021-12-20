using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossScript : MonoBehaviour
{
    [SerializeField]
    private skullKey skullCount;

    [SerializeField]
    private GameObject target1;
    [SerializeField]
    private GameObject target2;
    [SerializeField]
    private GameObject target3;

    private bool wait = false;

    [SerializeField]
    private Transform eye1;
    [SerializeField]
    private Transform eye2;
    [SerializeField]
    private GameObject lava;


    void Update()
    {
        if (skullCount.eyes >= 2)
        {
            Destroy(this.gameObject);
            skullCount.eyes = 0;
            skullCount.done = true;
        }

        if (wait == false)
        {
            StartCoroutine(bossPattern());
        }
    }

    IEnumerator bossPattern()
    {
        wait = true;

        transform.rotation = Quaternion.Euler(0, 0, -180f);
        transform.position = target2.transform.position;
        Instantiate(lava, eye1.position, eye1.rotation);
        Instantiate(lava, eye2.position, eye2.rotation);
        yield return new WaitForSeconds(4.0f);

        transform.rotation = Quaternion.Euler(0, 0, -90f);
        transform.position = target3.transform.position;
        Instantiate(lava, eye1.position, eye1.rotation);
        Instantiate(lava, eye2.position, eye2.rotation);
        yield return new WaitForSeconds(4.0f);


        transform.rotation = Quaternion.Euler(0, 0, -180f);
        transform.position = target2.transform.position;
        Instantiate(lava, eye1.position, eye1.rotation);
        Instantiate(lava, eye2.position, eye2.rotation);
        yield return new WaitForSeconds(4.0f);

        transform.rotation = Quaternion.Euler(0, 0, -90f);
        transform.position = target1.transform.position;
        Instantiate(lava, eye1.position, eye1.rotation);
        Instantiate(lava, eye2.position, eye2.rotation);
        yield return new WaitForSeconds(4.0f);
        wait = false;

    }
}
