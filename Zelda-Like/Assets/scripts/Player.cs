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
    [SerializeField]
    private Text bossKeyScore;
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
    bool coolDown3 = false;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private GameObject fireAbility;

    /*[SerializeField]
    private float stamina;
    [SerializeField]
    private float maxStamina;

    private bool inUse = false;*/

    public staminaBar stam;

    [SerializeField]
    private ForestPuzzleCheck puzz;

    [SerializeField]
    private GameObject circle;

    public SpriteRenderer m_SpriteRenderer;
    Color32 hit = new Color32(255, 255, 255, 0);
    Color32 normal = new Color32(255, 255, 255, 255);

    bool invincible = false;
    bool usable;

    [SerializeField]
    private Text winText;

    //public bool speedStatusEffect = false;

    void Start()
    {
        Array.Clear(puzz.rooms, 0, puzz.rooms.Length);
        Array.Clear(stats.skills, 0, stats.skills.Length);
        stats.speedStatusEffect = false;
        stats.grabbedStatusEffect = false;
        stats.healthHolder = 10;
        stats.health = stats.healthHolder;
        stats.keys = 0;
        stats.bossKeys = 0;
        stats.fbTempHealth = stats.finalBossHealth;
        stam.setMaxStamina(stats.maxStamina);
        //skullCount.done = false;
        escaped.enabled = false;
        winText.enabled = false;
        weapon.SetActive(false);
        Physics2D.IgnoreLayerCollision(3, 6, true);
        Physics2D.IgnoreLayerCollision(3, 16, true);
        Physics2D.IgnoreLayerCollision(3, 11, true);
        Physics2D.IgnoreLayerCollision(6, 9, true);
        Physics2D.IgnoreLayerCollision(10, 15, true);
        Physics2D.IgnoreLayerCollision(13, 15, true);
        Physics2D.IgnoreLayerCollision(9, 13, true);
        Physics2D.IgnoreLayerCollision(9, 10, true);
        Physics2D.IgnoreLayerCollision(10, 15, true);
        Physics2D.IgnoreLayerCollision(6, 14, true);
        stats.noGrab = true;
        stats.hit = false;
        stats.inUse = false;
    }

    void Update()
    {
        if (stats.fbTempHealth <= 0)
        {
            winText.text = "Congrats You Won!That's It For Now.";
        }
        textScore.text = "X " + stats.keys;
        bossKeyScore.text = "X " + stats.bossKeys + "/" + stats.bossKeyNeeded;
        if (stats.stamina < 0)
        {
            stats.stamina = 0;
        }
        if(stats.stamina > 5)
        {
            stats.stamina = 5;
        }
        if(stats.inUse == false && stats.stamina < 5 && coolDown2 == false)
        {
            StartCoroutine(staminaGain());
        }

        stam.setStamina(stats.stamina);

        if(stats.grabbedStatusEffect == true)
        {
  //player.transform.localPosition = new Vector3(0, 0, 0);
            frontOfPlayer.transform.localPosition = new Vector3(0.1999898f, -16f, 0.0f);
        }
        circle.transform.localPosition = new Vector3(0f, 0f, 0f);

        rb.WakeUp();

        for (int i = 0; i < stats.skillUse.Length; i++)
        {
            if (stats.skillUse[i])
            {
                usable = false;
            }
            else
            {
                usable = true;
            }
        }

        if (stats.hit == true && coolDown3 == false)
        {
            healthScore.text = "Health: " + stats.health;
            StartCoroutine(invincibilityFrames());
        }

        if(stats.health < 0)
        {
            stats.health = 0;
        }

        healthScore.text = "Health: " + stats.health;
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
        //
        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0 && Input.GetKey(KeyCode.X) && stats.stamina > 0 && stats.skills[1] == true)
        {
            fireAbility.SetActive(true);
            fireRB.position = fireRB.position + movementDirection * Time.deltaTime * stats.speed;
            if (stats.speedStatusEffect == false)
            {
                stats.speed = stats.speedHolder;
            }
            Physics2D.IgnoreLayerCollision(3, 9, true);
            Physics2D.IgnoreLayerCollision(3, 10, true);
            Physics2D.IgnoreLayerCollision(3, 12, true);
            Physics2D.IgnoreLayerCollision(3, 14, true);
            stats.stamina -= .1f;
            stats.inUse = true;
        }
        else if (stats.skills[1] == true && Input.GetAxisRaw("Horizontal") > 0 && Input.GetKey(KeyCode.X) && stats.stamina > 0 || stats.skills[1] == true && Input.GetAxisRaw("Vertical") > 0 && Input.GetKey(KeyCode.X) && stats.stamina > 0 || stats.skills[1] == true && Input.GetAxisRaw("Horizontal") < 0 && Input.GetKey(KeyCode.X) && stats.stamina > 0 || stats.skills[1] == true && Input.GetAxisRaw("Vertical") < 0 && Input.GetKey(KeyCode.X) && stats.stamina > 0)
        {
            fireAbility.SetActive(true);
            fireRB.position = fireRB.position + movementDirection * Time.deltaTime * stats.speed;
            stats.speed = 20;
            Physics2D.IgnoreLayerCollision(3, 9, true);
            Physics2D.IgnoreLayerCollision(3, 10, true);
            Physics2D.IgnoreLayerCollision(3, 12, true);
            Physics2D.IgnoreLayerCollision(3, 14, true);
            stats.stamina -= .3f;
            stats.inUse = true;
        }
        else if (Input.GetKey(KeyCode.X) && stats.stamina == 0)
        {
            stats.inUse = true;
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
                Physics2D.IgnoreLayerCollision(3, 12, false);
                player.transform.rotation = Quaternion.identity;
                player.transform.parent = null;
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
                Physics2D.IgnoreLayerCollision(3, 12, false);
                player.transform.rotation = Quaternion.identity;
                player.transform.parent = null;
            }

            //
            if (stats.skillUse[2] == false)
            {
                stats.inUse = false;
            }
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
            player.transform.position = teleportTarget.transform.position;
            stats.health = stats.healthHolder;
            healthScore.text = "Health: " + stats.health;
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

        if (Input.GetKey(KeyCode.Z) && coolDown == false && usable)
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
            //textScore.text = "Keys: " + stats.keys;
        }
        if (collision.gameObject.tag == "bossBarrier" && stats.bossKeys >= stats.bossKeyNeeded)
        {
            Destroy(collision.gameObject);
            stats.bossKeys -= stats.bossKeyNeeded;
        }
        if (collision.gameObject.tag == "lava" || collision.gameObject.tag == "enemy" || collision.gameObject.tag == "fire" && stats.health > 0)
        {
            if (invincible == false)
            {
                stats.health--;
            }
            healthScore.text = "Health: " + stats.health;
            if (coolDown3 == false)
            {
                StartCoroutine(invincibilityFrames());
            }
        }

        Debug.Log(collision.gameObject);
    }
    
    void OnCollisionStay2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "block")
        {
            animator.SetBool("pushing", true);
        }
        if (coll.gameObject.tag == "block" && animator.GetFloat("horizontal") == 0 && animator.GetFloat("vertical") == 0)
        {
            animator.SetBool("pushing", false);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "block")
        {
            animator.SetBool("pushing", false);
        }
    }

    IEnumerator attack()
    {
        coolDown = true;
        stats.skillUse[1] = true;
        Debug.Log("couroutine");
        weapon.SetActive(true);
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(.25f);
        weapon.SetActive(false);
        animator.SetBool("isAttacking", false);
        stats.skillUse[1] = false;
        coolDown = false;
    }

    IEnumerator staminaGain()
    {
        coolDown2 = true;
        yield return new WaitForSeconds(.5f);
        stats.stamina += 1f;
        coolDown2 = false;
    }

    IEnumerator invincibilityFrames()
    {
        coolDown3 = true;
        invincible = true;
        m_SpriteRenderer.color = hit;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = normal;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = hit;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = normal;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = hit;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = normal;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = hit;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = normal;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = hit;
        yield return new WaitForSeconds(.2f);
        m_SpriteRenderer.color = normal;
        invincible = false;
        coolDown3 = false;
        stats.hit = false;
    }
}
