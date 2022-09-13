using UnityEngine;

public class EnemyProjectile : Enemy_Damge // Inherit from enemy damage to damage the player if it touches player
{
    //damage coming from enemy_damage script no need to place it in again
    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;

    public void ActivateArrow()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //base needed as it will excute OnTrigger in EnemyDamge first so player actually takes damage
        base.OnTriggerEnter2D(collision); // executes logic from parent i.e Enemy_Damage
        gameObject.SetActive(false); // when trap arrow collides it deactivates
    }
}
