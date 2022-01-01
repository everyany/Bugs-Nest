using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "puzzle order", menuName = "the order of puzzles")]
public class PuzzleOrder : ScriptableObject
{
    public bool[] puzzleActivated;
    public bool notInOrder;
    public bool done;
}