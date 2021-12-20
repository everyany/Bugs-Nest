using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTheDoor : MonoBehaviour
{
    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;
    [SerializeField]
    private int numOfEvents;

    private bool done = false;

    public Animator animator;

    void Update()
    {
        if (puzz.rooms[roomNum] == numOfEvents && done == false)
        {
            animator.SetBool("solved", true);
            done = true;
        }
    }
}
