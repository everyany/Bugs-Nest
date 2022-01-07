using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitProtection : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Physics2D.IgnoreLayerCollision(3, 9, true);
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Physics2D.IgnoreLayerCollision(3, 9, false);
        }
    }
}
