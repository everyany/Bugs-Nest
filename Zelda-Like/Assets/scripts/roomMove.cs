using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomMove : MonoBehaviour
{
    public Vector2 min;
    public Vector2 max;
    public Vector3 playerChange;
    private cameraMovement cam;

    void Start()
    {
        cam = Camera.main.GetComponent<cameraMovement>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            cam.minPosition = min;
            cam.maxPosition = max;
            //other.transform.position += playerChange;
        }
    }
}
