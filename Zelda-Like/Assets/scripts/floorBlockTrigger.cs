using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorBlockTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject key;
    [SerializeField]
    private Transform keyPoint;
    [SerializeField]
    private Transform realKeyPoint;
    [SerializeField]
    private GameObject pressedFloorBlock;

    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.gameObject.tag == "Player")
        {
            Instantiate(pressedFloorBlock, keyPoint.position, keyPoint.rotation);
            Instantiate(key, realKeyPoint.position, realKeyPoint.rotation);

            Destroy(this.gameObject);
        }
    }
}
