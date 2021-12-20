using UnityEngine;

public class elasticFly : MonoBehaviour
{
    public Transform target;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private playerStats stats;
    public Animator animator;

    private bool grabbed = false;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player" && grabbed == false)
        {
            stats.speedStatusEffect = true;
            stats.speed = 0f;
            player.transform.parent = this.gameObject.transform;
            stats.grabbedStatusEffect = true;
            player.transform.rotation = Quaternion.identity;
            Physics2D.IgnoreLayerCollision(3, 9, true);
            Physics2D.IgnoreLayerCollision(9, 12, true);
            animator.SetBool("flying", true);
            grabbed = true;
        }

        if (collider.gameObject.tag == "flammable")
        {
            Physics2D.IgnoreLayerCollision(3, 12, true);
        }
    }
}