using UnityEngine;

public class Player : MonoBehaviour
{
    private float xInput;
    [Header("Speed and Jump")]
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isRunning;
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
        if (!isRunning)
            rb.velocity = new Vector2(xInput * walkingSpeed, rb.velocity.y);
        else
            rb.velocity = new Vector2(xInput * runningSpeed, rb.velocity.y);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else
        {
            isRunning = Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow));
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
        var isWalking = rb.velocity.x != 0 && !isRunning;
        anim.SetBool("isWalking", isWalking);
        anim.SetBool("isRunning", isRunning);
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