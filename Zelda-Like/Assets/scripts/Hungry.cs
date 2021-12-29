using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hungry : MonoBehaviour
{
    [SerializeField]
    private ForestPuzzleCheck puzz;
    [SerializeField]
    private int roomNum;

    private bool done = false;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "block")
        {
            if (roomNum != 0)
            {
                puzz.rooms[roomNum]++;
            }
            spriteRenderer.sprite = newSprite;
        }
    }
}
