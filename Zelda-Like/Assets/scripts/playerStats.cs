using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerstats", menuName = "numeric player values")]
public class playerStats : ScriptableObject
{
    public int health;
    public float speed;
    public float speedHolder;
    public bool speedStatusEffect;
    public bool grabbedStatusEffect;
    public float keys;
    public bool noGrab;
    public bool[] skills;
    public bool[] skillUse;
    public bool hit;
}
