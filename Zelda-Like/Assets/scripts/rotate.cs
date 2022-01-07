using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private float rotz;
    [SerializeField]
    private float RotationSpeed;
    bool ClockwiseRotation = false;

    bool coolDown = false;

    void Update()
    {
        if (coolDown == false)
        {
            StartCoroutine(rotationChange());
        }

        if (ClockwiseRotation == false)
        {
            rotz += Time.deltaTime * RotationSpeed;
        }
        else
        {
            rotz += -Time.deltaTime * RotationSpeed;
        }

        transform.rotation = Quaternion.Euler(0, 0, rotz);
    }

    IEnumerator rotationChange()
    {
        coolDown = true;
        yield return new WaitForSeconds(3.5f);
        if (ClockwiseRotation == false)
        {
            ClockwiseRotation = true;
        }
        else if(ClockwiseRotation == true)
        {
            ClockwiseRotation = false;
        }
        coolDown = false;
    }
}
