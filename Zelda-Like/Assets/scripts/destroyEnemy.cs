using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyEnemy : MonoBehaviour
{
    private bool coolDown = false;
    [SerializeField]
    private float time = 45f;

    void Update()
    {
        if (coolDown == false)
        {
            StartCoroutine(kill());
        }
    }
    IEnumerator kill()
    {
        coolDown = true;
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
        coolDown = false;
    }
}
