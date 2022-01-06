using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossFireBlast : MonoBehaviour
{
    [SerializeField] private int direction;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField]
    private float speed = .7f;
    void Update()
    {
        switch (direction)
        {
            case 1:
                rb.velocity = new Vector3(speed, speed, 0);
                break;
            case 2:
                rb.velocity = new Vector3(-speed, -speed, 0);
                break;
            case 3:
                rb.velocity = new Vector3(-speed, speed, 0);
                break;
            case 4:
                rb.velocity = new Vector3(speed, -speed, 0);
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player" || coll.gameObject.tag == "wall" || coll.gameObject.tag == "playerCircle")
        {
            Debug.Log("it hit the wall");
            Destroy(this.gameObject);
        }
    }
}
