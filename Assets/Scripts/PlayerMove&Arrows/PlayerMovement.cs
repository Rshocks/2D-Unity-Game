using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField]private float jumpPower;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private LayerMask wallLayer;

    private float wallJumpCooldown;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horizontalInput;

    [Header ("Sound")]
    [SerializeField] private AudioClip JumpSound;

    // awake called everytime script is loaded
    private void Awake()
    {
        //get ref for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //update every frame when player presses movemnt
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //turning/fliping left and right
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(1,1,1);

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1,1,1);

        //jumping
        if(Input.GetKey(KeyCode.Space)) //&& isGrounded())
        Jump();

        //setting the animator param
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", isGrounded());



        //wall jump logic
        if (wallJumpCooldown > 0.2f)
        {

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }

            //pulls player back down using gravity scale in unity
            else
                body.gravityScale = 2;

            //jumping
            if(Input.GetKey(KeyCode.Space))
            {
                Jump();

                if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
                     SoundManger.instance.PlaySound(JumpSound);
            }
        }

        //cooling down wall jump
           else
           wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if(isGrounded())
        {
            anim.SetTrigger("Jump");
            body.velocity = new Vector2(body.velocity.x, jumpPower);

        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 5, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            wallJumpCooldown = 0;
        }
    }


   private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0; //&& isGrounded() && !onWall();
    }
}
