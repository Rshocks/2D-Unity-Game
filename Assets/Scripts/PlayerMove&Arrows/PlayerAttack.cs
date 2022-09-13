using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private AudioClip ArrowSound;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.F) && cooldownTimer > attackCooldown && playerMovement.canAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        SoundManger.instance.PlaySound(ArrowSound);
        anim.SetTrigger("Attack");
        cooldownTimer = 0;

        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if(!arrows[i].activeInHierarchy)
            return i;
        }
        return 0;
    }
}
