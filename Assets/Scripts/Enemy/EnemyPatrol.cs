using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform LeftEdge;
    [SerializeField] private Transform RightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform Enemy;

    [Header ("Movement Params")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    private float IdleTimer;
    [SerializeField] private float IdleDuration;
    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = Enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("Moving", false);
    }

    private void Update()
    {
        if(movingLeft)
        {
            if(Enemy.position.x >= LeftEdge.position.x)
            MoveInDirection(-1);
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if(Enemy.position.x <= RightEdge.position.x)
            MoveInDirection(1);
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("Moving", false);

        IdleTimer += Time.deltaTime;
        if(IdleTimer > IdleDuration)

        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction)
    {
        IdleTimer = 0;
        anim.SetBool("Moving", true);
        //Make enemy face direction
        Enemy.localScale = new Vector3(Mathf.Abs (initScale.x) * _direction, initScale.y, initScale.z);
        //Move in said direction
        Enemy.position = new Vector3(Enemy.position.x + Time.deltaTime * _direction * speed,
        Enemy.position.y, Enemy.position.z);
    }

}
