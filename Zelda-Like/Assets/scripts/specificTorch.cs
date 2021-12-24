using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specificTorch : MonoBehaviour
{
    [SerializeField]
    private Transform flammable;
    [SerializeField]
    private GameObject fire;
    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;

    private bool done = false;
    private bool burning = false;
    private GameObject fireClone;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject web;
    [SerializeField]
    private playerStats stats;

    void Start()
    {
        if (roomNum != 0)
        {
            puzz.rooms[roomNum] = 0;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.X) && stats.skills[1] == true)
        {
            player.transform.parent = null;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "fire" && done == false)
        {
            fireClone = Instantiate(fire, flammable.position, flammable.rotation);
            done = true;
            if (roomNum != 0)
            {
                puzz.rooms[roomNum]++;
            }
            if (this.gameObject.tag == "flammable" && burning == false)
            {
                StartCoroutine(burn());
            }
        }
    }

    IEnumerator burn()
    {
        burning = true;
        yield return new WaitForSeconds(.1f);
        Destroy(fireClone);
        web.SetActive(false);
        yield return new WaitForSeconds(1f);
        web.gameObject.SetActive(true);
        burning = false;
        done = false;
    }
}