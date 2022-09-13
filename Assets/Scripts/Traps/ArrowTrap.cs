using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] Arrows;
    private float cooldownTimer;

    [Header ("Sound")]
    [SerializeField] private AudioClip TrapSound;

    private void Attack()
    {
        cooldownTimer = 0;

        SoundManger.instance.PlaySound(TrapSound);
        Arrows[FindArrow()].transform.position = firePoint.position;
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

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(cooldownTimer >= attackCooldown)
        Attack();
    }

    

}
