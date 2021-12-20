using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyDoor : MonoBehaviour
{
    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;
    [SerializeField]
    private int numOfEvents;

    private bool done = false;

    void Update()
    {
        if (puzz.rooms[roomNum] == numOfEvents && done == false)
        {
            Destroy(this.gameObject);
            done = true;
        }
    }
}
