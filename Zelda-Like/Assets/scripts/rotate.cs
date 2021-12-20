using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private float rotz;
    [SerializeField]
    private float RotationSpeed;
    [SerializeField]
    private bool ClockwiseRotation;
    void Update()
    {
        if(ClockwiseRotation == false)
        {
            rotz += Time.deltaTime * RotationSpeed;
        }
        else
        {
            rotz += -Time.deltaTime * RotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotz);
    }
}
