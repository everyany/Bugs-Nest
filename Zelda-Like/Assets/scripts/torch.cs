using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
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

    void Start()
    {
        if (roomNum != 0)
        {
            puzz.rooms[roomNum] = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "fire" && done == false)
        {
            fireClone = Instantiate(fire, flammable.position, flammable.rotation);
            done = true;
            if(roomNum != 0)
            {
                puzz.rooms[roomNum]++;
            }
            if(this.gameObject.tag == "flammable" && burning == false)
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
        Destroy(this.gameObject);
    }
}
