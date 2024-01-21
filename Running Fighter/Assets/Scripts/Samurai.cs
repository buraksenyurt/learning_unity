using UnityEditor.Callbacks;
using UnityEngine;

public class Samurai : Entity
{
    bool isAttacking;
    protected new Animator animator;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;

    [Header("Player Detection")]
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;
    private RaycastHit2D isPlayerDetected;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (isPlayerDetected)
        {
            Debug.Log("Player detected");
            if (isPlayerDetected.distance > 1)
            {
                rigidbody.velocity = new Vector2(moveSpeed * 1.5f * facingDirection, rigidbody.velocity.y);
                Debug.Log("Player is coming");
                isAttacking = false;
            }
            else
            {
                Debug.Log($"{isPlayerDetected.collider.gameObject.name} is attacking");
                isAttacking = true;
            }
        }
        isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance * facingDirection, groundType);
        if (isWallDetected)
            Flip();

        if (!isAttacking)
            rigidbody.velocity = new Vector2(moveSpeed * facingDirection, rigidbody.velocity.y);
    }
    protected override void CheckCollision()
    {
        base.CheckCollision();
        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.left, playerCheckDistance * facingDirection, whatIsPlayer);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + playerCheckDistance * facingDirection, transform.position.y));
    }
}
