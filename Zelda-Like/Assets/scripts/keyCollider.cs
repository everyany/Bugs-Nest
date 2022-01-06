using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyCollider : MonoBehaviour
{
    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;

    bool itsIn = false;

    void OnCollisionStay2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "keyPart" && itsIn == false)
        {
            puzz.rooms[roomNum]++;
            itsIn = true;
        }
    }
    void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "keyPart" && itsIn == true)
        {
            puzz.rooms[roomNum]--;
            itsIn = false;
        }
    }
}
