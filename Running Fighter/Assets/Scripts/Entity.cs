using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Animator animator;
    protected new Rigidbody2D rigidbody;
    protected bool isOnTheGround;
    [Header("Collision Settings")]
    [SerializeField] protected float checkDistance;
    [SerializeField] protected LayerMask groundType;
    [SerializeField] protected Transform groundCheck;
    protected int facingDirection = 1;
    protected bool facingRight = true;
    protected virtual void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Update()
    {
        CheckCollision();
    }

    protected virtual void CheckCollision()
    {
        isOnTheGround = Physics2D.Raycast(groundCheck.position, Vector2.down, checkDistance, groundType);
    }

    protected void Flip()
    {
        facingDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - checkDistance));
    }
}
