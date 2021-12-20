using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericKeySpawn : MonoBehaviour
{
    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;
    [SerializeField]
    private int numOfEvents;
    [SerializeField]
    private Transform keySpawn;
    [SerializeField]
    private GameObject key;

    private bool done = false;

    void Update()
    {
        if (puzz.rooms[roomNum] == numOfEvents && done == false)
        {
            Instantiate(key, keySpawn.position, keySpawn.rotation);
            done = true;
        }
    }
}
