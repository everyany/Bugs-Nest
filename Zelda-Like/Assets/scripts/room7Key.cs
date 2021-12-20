using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room7Key : MonoBehaviour
{
    [SerializeField]
    private int roomNum;
    [SerializeField]
    private Room7Enemies enemies;
    [SerializeField]
    private Transform keySpawn;
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private int numOfEvents;

    private bool done = false;

    void Update()
    {
        if (enemies.enemies[roomNum] == numOfEvents && done == false)
        {
            Instantiate(key, keySpawn.position, keySpawn.rotation);
            done = true;
        }
    }
}
