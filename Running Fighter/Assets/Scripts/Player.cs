using UnityEngine;

public class Player : MonoBehaviour
{
    private float xInput;
    [Header("Speed and Jump")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private Animator anim;
    //[SerializeField] private bool isMoving;
    private int facingDirection = 1;
    private bool facingRight = true;
    [Header("Ground Collision Settings")]
    [SerializeField] private float checkDistance;
    [SerializeField] private LayerMask groundType;
    private bool isOnTheGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Movement();
        CheckInput();
        CheckOnGround();
        FlipController();
        AnimatorControllers();
    }

    private void CheckOnGround()
    {
        isOnTheGround = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, groundType);
    }

    private void Movement()
    {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (isOnTheGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void AnimatorControllers()
    {
        var isMoving = rb.velocity.x != 0;
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isOnTheGround", isOnTheGround);
    }

    private void Flip()
    {
        facingDirection *= -1;
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if (rb.velocity.x > 0 && !facingRight)
            Flip();
        else if (rb.velocity.x < 0 && facingRight)
            Flip();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - checkDistance));
    }
}