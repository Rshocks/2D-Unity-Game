using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float StartingHealth;

    public float CurrentHealth;
    private BoxCollider2D Box;
    private Animator anim;
    private bool dead;

    [Header ("iFrames")]
    [SerializeField] private float iFramesTime;
    [SerializeField] private float NumofFlashs;
    private SpriteRenderer spriteRend;

    [Header ("Sound")]
    [SerializeField] private AudioClip DeathSound;
    [SerializeField] private AudioClip Hurt;


    private void Awake()
    {
        CurrentHealth = StartingHealth;
        Box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _damage, 0, StartingHealth);

        if (CurrentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("Hurt");
            //iframes
            StartCoroutine(Invunerablity());
            SoundManger.instance.PlaySound(Hurt);
        }
        else
        {
            if(!dead)
            {
                Box.GetComponent<BoxCollider2D>().enabled = false;
                anim.SetTrigger("Die");

                //player dead
                if(GetComponent<PlayerMovement>() != null)
                    GetComponent<PlayerMovement>().enabled = false;

                //Enemy dead
                if(GetComponentInParent<EnemyPatrol>() != null)
                    GetComponentInParent<EnemyPatrol>().enabled = false;
                
                if(GetComponent<EnemyMelee>() != null)
                    GetComponent<EnemyMelee>().enabled = false;

                if(GetComponent<RangedEnemy>() != null)
                    GetComponent<RangedEnemy>().enabled = false;

                if(GetComponent<Sheriff>() != null)
                    GetComponent<Sheriff>().enabled = false;

                dead = true;
                SoundManger.instance.PlaySound(DeathSound);
            }
        }
    }

    public void AddHealth(float _value)
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + _value, 0, StartingHealth);
    }

    private IEnumerator Invunerablity()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for ( int i = 0; i < NumofFlashs; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f); // changes color to red & transparent when hit
            yield return new WaitForSeconds(iFramesTime / (NumofFlashs)); // wait for one second
            
            spriteRend.color = Color.white; // changes back to original
            yield return new WaitForSeconds(iFramesTime / (NumofFlashs)); // wait for one second

        }
        // iframe time 
        Physics2D.IgnoreLayerCollision(10, 11, false);

    }

}
