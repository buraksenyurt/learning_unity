using UnityEngine;

public class Samurai : Entity
{
    protected new Animator animator;

    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        isWallDetected = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance * facingDirection, groundType);
        if (isWallDetected)
            Flip();

        rigidbody.velocity = new Vector2(moveSpeed * facingDirection, rigidbody.velocity.y);
    }
}
