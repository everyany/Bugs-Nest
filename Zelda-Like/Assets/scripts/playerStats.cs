using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "playerstats", menuName = "numeric player values")]
public class playerStats : ScriptableObject
{
    public int healthHolder;
    public int health;
    public float speed;
    public float speedHolder;
    public bool speedStatusEffect;
    public bool grabbedStatusEffect;
    public float keys;
    public int bossKeys;
    public int bossKeyNeeded;
    public bool noGrab;
    public bool[] skills;
    public bool[] skillUse;
    public bool hit;
    public bool bossStart;
    public bool finalBossStart;
    public float stamina;
    public float maxStamina;
    public bool inUse = false;
    public int bossHealth;
    public int finalBossHealth;
    public int fbTempHealth;
}
