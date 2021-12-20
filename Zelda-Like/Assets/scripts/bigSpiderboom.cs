using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigSpiderboom : MonoBehaviour
{
    [SerializeField]
    private ForestPuzzleCheck puzz;
    void Update()
    {
        if(puzz.rooms[8] == 1)
        {
            Destroy(this.gameObject);
        }
    }
}
