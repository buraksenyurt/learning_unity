using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Dash Info")]
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashSpeed;

    private float xInput;
    [Header("Speed and Jump")]
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isRunning;
    private bool isWalking;
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
        dashTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.S))
        {
            dashTime = dashDuration;
        }
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
        if (dashTime > 0)
        {
            rb.velocity = new Vector2(xInput * dashSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(xInput * walkingSpeed, rb.velocity.y);
        }
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
            isRunning = Input.GetKey(KeyCode.S) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && dashTime > 0;
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
        isWalking = rb.velocity.x != 0 && !isRunning;
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