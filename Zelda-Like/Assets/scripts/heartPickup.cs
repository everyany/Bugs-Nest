using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class heartPickup : MonoBehaviour
{
    [SerializeField]
    private playerStats stats;

    public bool final;

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && Input.GetKey(KeyCode.Z))
        {
            Destroy(this.gameObject);
            stats.health = stats.healthHolder;
            stats.health++;
            stats.healthHolder++;

            if(final)
                SceneManager.LoadScene("End");
        }
    }
}
