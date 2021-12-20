using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sister : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer currSprite;
    [SerializeField]
    private Sprite left;
    [SerializeField]
    private Sprite right;
    [SerializeField]
    private Sprite up;
    [SerializeField]
    private Sprite down;

    void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            currSprite.sprite = left;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            currSprite.sprite = right;
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            currSprite.sprite = down;
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            currSprite.sprite = up;
        }
    }
}
