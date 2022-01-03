using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class torchRoom10 : MonoBehaviour
{
    [SerializeField]
    private Transform flammable;
    [SerializeField]
    private GameObject fire;
    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;
    [SerializeField]
    private int torchNum;

    private bool burning = false;
    private GameObject fireClone;

    [SerializeField]
    private PuzzleOrder torches;

    int torchCounter = 0;

    bool torchZero;

    void Start()
    {
        if (roomNum != 0)
        {
            puzz.rooms[roomNum] = 0;
            Array.Clear(torches.puzzleActivated, 0, torches.puzzleActivated.Length);
        }
        torches.done = false;
        torchZero = false;
    }

    void Update()
    {
        /*if(torches.notInOrder == true && burning == false)
        {
            Destroy(fireClone);
            burning = false;
            torches.notInOrder = false;
        }*/
        if (roomNum != 0 && puzz.rooms[roomNum] >= 4)
        {
            torches.done = true;
        }
        if (puzz.rooms[roomNum] < 0)
        {
            puzz.rooms[roomNum] = 0;
        }

        if (torches.puzzleActivated[0] && torches.puzzleActivated[1] && torches.puzzleActivated[2] && torches.puzzleActivated[3])
        {
            puzz.rooms[roomNum] = 4;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "fire" && torches.puzzleActivated[torchNum] == false)
        {
            if (torchNum == 0 && torches.puzzleActivated[0] == false && torches.puzzleActivated[1] == true || torchNum == 0 && torches.puzzleActivated[0] == false && torches.puzzleActivated[2] == true || torchNum == 0 && torches.puzzleActivated[0] == false && torches.puzzleActivated[3] == true)
            {
                torches.puzzleActivated[0] = true;
                torches.puzzleActivated[1] = false;
                torches.puzzleActivated[2] = false;
                torches.puzzleActivated[3] = false;
            }
            if(torchNum == 0 && torches.puzzleActivated[0] == false && torches.puzzleActivated[1] == false && torches.puzzleActivated[2] == false && torches.puzzleActivated[3] == false)
            {
                torches.puzzleActivated[0] = true;
                torchZero = true;
            }
            else if (torchNum == 1 && torches.puzzleActivated[1] == false && torches.puzzleActivated[0] == true && torches.puzzleActivated[2] == false && torches.puzzleActivated[3] == false)
            {
                torches.puzzleActivated[1] = true;
                torchZero = true;
            }
            else if (torchNum == 2 && torches.puzzleActivated[2] == false && torches.puzzleActivated[0] == true && torches.puzzleActivated[1] == true && torches.puzzleActivated[3] == false)
            {
                torches.puzzleActivated[2] = true;
                torchZero = true;
            }
            else if (torchNum == 3 && torches.puzzleActivated[3] == false && torches.puzzleActivated[0] == true && torches.puzzleActivated[1] == true && torches.puzzleActivated[2] == true)
            {
                torches.puzzleActivated[3] = true;
                torchZero = true;
            }
            else
            {
                torchZero = false;
            }

            if (burning == false && torches.done == false)
            {
                StartCoroutine(burn());
            }
        }
    }

    IEnumerator burn()
    {
        burning = true;
        fireClone = Instantiate(fire, flammable.position, flammable.rotation);
        fireClone.transform.parent = this.gameObject.transform;
        torchCounter++;

        if(roomNum != 0 && torches.puzzleActivated[torchNum] && puzz.rooms[roomNum] < 4)
        {
            puzz.rooms[roomNum]++;
        }
        
        yield return new WaitForSeconds(7f);
        
        if (torches.done == false)
        {
            Destroy(fireClone);
            if(torchZero == true && torchNum != 0)
            {
                puzz.rooms[roomNum]--;
            }
            else if(torchZero == true && torchNum == 0)
            {
                puzz.rooms[roomNum] = 0;
            }
            
            torchCounter = 0;
            torches.notInOrder = true;
            torches.puzzleActivated[torchNum] = false;
            torchZero = false;
            burning = false;
        }
    }
}