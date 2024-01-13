using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Animator animator;
    protected new Rigidbody2D rigidbody;
    protected bool isOnTheGround;
    protected bool isWallDetected;
    [Header("Collision Settings")]
    [SerializeField] protected float groundCheckDistance;
    [SerializeField] protected LayerMask groundType;
    [SerializeField] protected Transform groundCheck;
    [Space]
    [SerializeField] protected float wallCheckDistance;
    [SerializeField] protected Transform wallCheck;
    protected int facingDirection = 1;
    protected bool facingRight = true;
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        // if (wallCheck == null)
        //     wallCheck = transform;
    }

    protected virtual void Update()
    {
        CheckCollision();
    }

    protected virtual void CheckCollision()
    {
        isOnTheGround = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundType);
        //isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, groundType);
    }

    protected void Flip()
    {
        facingDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        //Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
}
