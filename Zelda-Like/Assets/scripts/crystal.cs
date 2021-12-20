using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crystal : MonoBehaviour
{
    [SerializeField]
    private skullKey skullCount;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "attack")
        {
            Destroy(this.gameObject);
            skullCount.crystals++;
            Debug.Log("count:" + skullCount.crystals);
        }
    }
}