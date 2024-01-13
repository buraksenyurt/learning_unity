using UnityEngine;

public class Shinobi : Entity
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
        if (!isOnTheGround || wallCheck)
            Flip();

        rigidbody.velocity = new Vector2(moveSpeed * facingDirection, rigidbody.velocity.y);
    }
}
