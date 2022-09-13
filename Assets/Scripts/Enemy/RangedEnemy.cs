using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header ("Attack Params")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float damage;

    [Header ("Ranged Attack")]
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] Arrows;

    [Header ("Collider Params")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header ("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header ("Sound")]
    [SerializeField] private AudioClip ArrowSoundTwo;

    //refernces
    private Health playerHealth;
    private Animator anim;

    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        //Attack only when player in sight
        if(PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown)
            {
                //Attack
                cooldownTimer = 0;
                anim.SetTrigger("RangedAttack");

            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private void RangedAttack()
    {
        SoundManger.instance.PlaySound(ArrowSoundTwo);
        cooldownTimer = 0;
        Arrows[FindArrow()].transform.position = firepoint.position;
        Arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateArrow();
    }

    private int FindArrow()
    {
        for(int i = 0; i < Arrows.Length; i++)
        {
            if(!Arrows[i].activeInHierarchy)
            return i;
        }
        return 0;
    }


   private bool PlayerInSight()
    {
        RaycastHit2D hit = 
            Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
