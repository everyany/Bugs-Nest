using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player : MonoBehaviour
{
    //public float speed = 5.0f;
    //public float speedHolder;

    [SerializeField]
    private playerStats stats;

    [SerializeField]
    private Text textScore;
    //[SerializeField]
    //private int keys = -1;
    //[SerializeField]
    //private int health = 9;
    [SerializeField]
    private Text healthScore;

    [SerializeField]
    private Text escaped;

    [SerializeField]
    private GameObject frontOfPlayer;

    public Transform teleportTarget;

    //[SerializeField]
    //private skullKey skullCount;

    [SerializeField]
    private Transform keyPoint;
    [SerializeField]
    private GameObject key;

    [SerializeField]
    private GameObject lava;

    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private GameObject player;

    //
    [SerializeField]
    private Rigidbody2D rb;
    //
    [SerializeField]
    private Rigidbody2D fireRB;

    public Animator animator;
    Vector2 movement;

    bool coolDown = false;
    bool coolDown2 = false;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private GameObject fireAbility;

    [SerializeField]
    private float stamina;
    [SerializeField]
    private float maxStamina;

    private bool inUse = false;

    public staminaBar stam;

    [SerializeField]
    private ForestPuzzleCheck puzz;

    //public bool speedStatusEffect = false;

    void Start()
    {
        Array.Clear(puzz.rooms, 0, puzz.rooms.Length);
        stats.speedStatusEffect = false;
        stats.grabbedStatusEffect = false;
        stats.health = 10;
        stats.keys = 0;
        stam.setMaxStamina(maxStamina);
        //skullCount.done = false;
        escaped.enabled = false;
        weapon.SetActive(false);
        Physics2D.IgnoreLayerCollision(3, 6, true);
        Physics2D.IgnoreLayerCollision(3, 11, true);
        Physics2D.IgnoreLayerCollision(6, 9, true);
        stats.noGrab = true;
    }

    void Update()
    {
        textScore.text = "Keys: " + stats.keys;
        if (stamina < 0)
        {
            stamina = 0;
        }
        if(stamina > 5)
        {
            stamina = 5;
        }
        if(inUse == false && stamina < 5 && coolDown2 == false)
        {
            StartCoroutine(staminaGain());
        }

        stam.setStamina(stamina);

        if(stats.grabbedStatusEffect == true)
        {
            transform.localPosition = new Vector3(0, 0, 0);
            frontOfPlayer.transform.localPosition = new Vector3(0.1999898f, -16f, 0.0f);
        }
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //
        //
        //
        /*if (skullCount.done == false)
        {*/
            if (Input.GetAxisRaw("Horizontal") < 1 || Input.GetAxisRaw("Vertical") < 1)
            {
                rb.velocity = Vector3.zero;
            }

            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            Vector2 movementDirection = new Vector2(horizontalInput, verticalInput);
            float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);
            movementDirection.Normalize();

            if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0 && Input.GetKey(KeyCode.X) && stamina > 0)
            {
                fireAbility.SetActive(true);
                fireRB.position = fireRB.position + movementDirection * Time.deltaTime * stats.speed;
                if (stats.speedStatusEffect == false)
                {
                    stats.speed = stats.speedHolder;
                }
                Physics2D.IgnoreLayerCollision(3, 9, true);
                Physics2D.IgnoreLayerCollision(3, 10, true);
                stamina -= .1f;
                inUse = true;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 && Input.GetKey(KeyCode.X) && stamina > 0 || Input.GetAxisRaw("Vertical") > 0 && Input.GetKey(KeyCode.X) && stamina > 0 || Input.GetAxisRaw("Horizontal") < 0 && Input.GetKey(KeyCode.X) && stamina > 0 || Input.GetAxisRaw("Vertical") < 0 && Input.GetKey(KeyCode.X) && stamina > 0)
            {
                fireAbility.SetActive(true);
                fireRB.position = fireRB.position + movementDirection * Time.deltaTime * stats.speed;
                stats.speed = 20;
                Physics2D.IgnoreLayerCollision(3, 9, true);
                Physics2D.IgnoreLayerCollision(3, 10, true);
                stamina -= .3f;
                inUse = true;
            }
            else if (Input.GetKey(KeyCode.X) && stamina == 0)
            {
                inUse = true;
                fireAbility.SetActive(false);
                if (stats.speedStatusEffect == false)
                {
                    stats.speed = stats.speedHolder;
                }
                if (stats.grabbedStatusEffect == false)
                {
                    Physics2D.IgnoreLayerCollision(3, 9, false);
                    Physics2D.IgnoreLayerCollision(3, 10, false);
                    Physics2D.IgnoreLayerCollision(3, 10, false);
                    Physics2D.IgnoreLayerCollision(3, 13, false);
                    Physics2D.IgnoreLayerCollision(3, 14, false);
            }
            }
            else
            {
                fireAbility.SetActive(false);
                if (stats.speedStatusEffect == false)
                {
                    stats.speed = stats.speedHolder;
                }
                if (stats.grabbedStatusEffect == false)
                {
                    Physics2D.IgnoreLayerCollision(3, 9, false);
                    Physics2D.IgnoreLayerCollision(3, 10, false);
                    Physics2D.IgnoreLayerCollision(3, 10, false);
                    Physics2D.IgnoreLayerCollision(3, 13, false);
                    Physics2D.IgnoreLayerCollision(3, 14, false);
            }
            inUse = false;
            }

            if (animator.GetBool("isAttacking") == false)
            {
                rb.position = rb.position + movementDirection * Time.deltaTime * stats.speed;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }

            if (movementDirection != Vector2.zero)
                {
                    Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, -movementDirection);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                }

                //
                animator.SetFloat("horizontal", movement.x);
                animator.SetFloat("vertical", movement.y);
                animator.SetFloat("speed", movement.sqrMagnitude);

                if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
                {
                    animator.SetFloat("lastMoveHorizontal", Input.GetAxisRaw("Horizontal"));
                    animator.SetFloat("lastMoveVertical", Input.GetAxisRaw("Vertical"));
                }
        //}
    

        if(stats.health == 0)
        {
            transform.position = teleportTarget.transform.position;
            stats.health += 10;
        }

        /*if(skullCount.skulls == 2)
        {
            Instantiate(key, keyPoint.position, keyPoint.rotation);
            skullCount.skulls = 0;
        }

        if (skullCount.crystals == 2)
        {
            Destroy(lava);
            skullCount.crystals = 0;
        }

        if(skullCount.done == true)
        {
            escaped.enabled = true;
        }*/

        frontOfPlayer.transform.localPosition = new Vector3(0.1999898f, -16f, 0.0f);

        if (Input.GetKey(KeyCode.Z) && coolDown == false)
        {
            Debug.Log("pressed");
            StartCoroutine(attack());
        }

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            weapon.transform.localPosition = new Vector3(0.0f, 1.2f, 0.0f);
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
        //
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "barrier" && stats.keys > 0)
        {
            Destroy(collision.gameObject);
            stats.keys--;
            textScore.text = "Keys: " + stats.keys;
        }
        if(collision.gameObject.tag == "lava" || collision.gameObject.tag == "pitfall" || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "fire" && stats.health > 0)
        {
            stats.health--;
            healthScore.text = "Health: " + stats.health;
        }

        Debug.Log(collision.gameObject);
    }

    IEnumerator attack()
    {
        coolDown = true;
        Debug.Log("couroutine");
        weapon.SetActive(true);
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(.25f);
        weapon.SetActive(false);
        animator.SetBool("isAttacking", false);
        coolDown = false;
    }

    IEnumerator staminaGain()
    {
        coolDown2 = true;
        yield return new WaitForSeconds(.5f);
        stamina += 1f;
        coolDown2 = false;
    }
}
