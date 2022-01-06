using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class hearts : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;
    [SerializeField]
    private GameObject[] heart;

    int tempHealth;

    int i = 0;
    int j = 0;

    /*void Start()
    {
        stats.healthHolder
    }*/

    void Update()
    {
        switch (stats.health)
        {
            case 0:
                for(i = 0; i < heart.Length; i++)
                {
                    heart[i].SetActive(false);
                }
                break;
            case 1:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 1; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 2:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 2; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 3:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 3; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 4:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 4; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 5:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 5; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 6:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 6; i++)
                {
                    heart[i].SetActive(true);
                }               
                break;
            case 7:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 7; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 8:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 8; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 9:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 9; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 10:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 10; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 11:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 11; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 12:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 12; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 13:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 13; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 14:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 14; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 15:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 15; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 16:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 16; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 17:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 17; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 18:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 18; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 19:
                for (j = 0; j < heart.Length; j++)
                {
                    heart[j].SetActive(false);
                }
                for (i = 0; i < 19; i++)
                {
                    heart[i].SetActive(true);
                }
                break;
            case 20:
                for (i = 0; i < 20; i++)
                {
                    heart[i].SetActive(true);
                }
                break;

        }
    }
}
