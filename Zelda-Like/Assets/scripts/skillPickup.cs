using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillPickup : MonoBehaviour
{
    [SerializeField]
    private int skillNumber;
    [SerializeField]
    private playerStats stats;

    public GameObject dialogue;

    void OnTriggerStay2D(Collider2D coll)
    {
        Debug.Log("You're in the trigger");
        if (coll.gameObject.tag == "Player" && Input.GetKey(KeyCode.Z))
        {
            stats.skills[skillNumber] = true;
            dialogue.SetActive(true);

            Destroy(this.gameObject);
        }
    }
}
