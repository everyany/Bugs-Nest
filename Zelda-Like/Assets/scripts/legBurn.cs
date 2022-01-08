using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class legBurn : MonoBehaviour
{
    private bool done = false;
    private bool burning = false;
    private GameObject fireClone;
    [SerializeField]
    private Transform flammable;
    [SerializeField]
    private GameObject fire;
    [SerializeField]
    private GameObject leg;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "fire" && done == false)
        {
            fireClone = Instantiate(fire, flammable.position, flammable.rotation);
            done = true;
            if (this.gameObject.tag == "flammable" && burning == false)
            {
                StartCoroutine(burn());
            }
        }
    }

    IEnumerator burn()
    {
        burning = true;
        yield return new WaitForSeconds(.1f);
        Destroy(fireClone);
        leg.SetActive(false);
        burning = false;
        done = false;
    }
}
