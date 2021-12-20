using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "skulls", menuName = "Skull key archive")]

public class skullKey : ScriptableObject
{
    public int skulls;
    public int crystals;
    public int eyes;
    public bool done;
}