using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeballSmack : MonoBehaviour
{
    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;

    private bool done = false;

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "attack" || coll.gameObject.tag == "fire" || coll.gameObject.tag == "sword" || coll.gameObject.tag == "bullet" && done == false)
        {
            done = true;
            if (roomNum != 0)
            {
                puzz.rooms[roomNum]++;
            }
            Destroy(this.gameObject);
        }
    }
}
