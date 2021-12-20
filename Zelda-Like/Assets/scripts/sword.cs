using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;
    [SerializeField]
    private GameObject player;
    public Animator animator;

    bool coolDown = false;

    void Start()
    {
        weapon.SetActive(false);
        Physics2D.IgnoreLayerCollision(3, 6, true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && coolDown == false)
        {
            Debug.Log("pressed");
            StartCoroutine(attack());
        }

        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            weapon.transform.localPosition = new Vector3(.5f, 1.2f, 0.0f);
        }

        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            weapon.transform.localPosition = new Vector3(.5f, 1.2f, 0.0f);
        }

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            weapon.transform.localPosition = new Vector3(0f, .7f, 0.0f);
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            weapon.transform.localPosition = new Vector3(.5f, 1.5f, 0.0f);
        }
    }

    IEnumerator attack()
    {
        coolDown = true;
        Debug.Log("couroutine");
        weapon.SetActive(true);
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(.15f);
        animator.SetBool("isAttacking", false);
        weapon.SetActive(false);
        yield return new WaitForSeconds(.15f);
        coolDown = false;
    }
}
