using UnityEngine;

public class Player : Entity
{
    [Header("Dash Info")]
    [SerializeField] private float dashDuration;
    private float dashTimer;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCoolDown;
    private float dashCoolDownTimer;

    private float xInput;
    [Header("Speed and Jump")]
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float jumpForce;
    private bool isRunning;
    private bool isWalking;
    [Header("Combo Attack")]
    [SerializeField] private float comboTime = 1f;
    private float comboTimeCounter;
    private bool isAttacking;
    private int comboCounter;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        Movement();
        CheckInput();
        FlipController();
        dashTimer -= Time.deltaTime;
        dashCoolDownTimer -= Time.deltaTime;
        comboTimeCounter -= Time.deltaTime;
        AnimatorControllers();
    }

    private void Movement()
    {
        if (isAttacking)
        {
            rigidbody.velocity = new Vector2(0, 0);
        }
        else if (dashTimer > 0 && isRunning)
        {
            rigidbody.velocity = new Vector2(xInput * dashSpeed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(xInput * walkingSpeed, rigidbody.velocity.y);
        }
    }

    public void StopAttacking()
    {
        isAttacking = false;
        comboCounter++;
        if (comboCounter > 2)
        {
            comboCounter = 0;
        }
    }

    private void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartAttack();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetDashTimers();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else
        {
            isRunning = Input.GetKey(KeyCode.S)
                && (Input.GetKey(KeyCode.LeftArrow)
                || Input.GetKey(KeyCode.RightArrow))
                && dashTimer > 0;
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
        if (comboTimeCounter < 0)
        {
            comboCounter = 0;
        }
        comboTimeCounter = comboTime;
    }

    private void SetDashTimers()
    {
        if (dashCoolDownTimer < 0)
        {
            dashTimer = dashDuration;
            dashCoolDownTimer = dashCoolDown;
        }
    }

    private void Jump()
    {
        if (isOnTheGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
    }

    private void AnimatorControllers()
    {
        isWalking = rigidbody.velocity.x != 0 && !isRunning;
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isOnTheGround", isOnTheGround);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetInteger("comboCounter", comboCounter);
    }

    private void FlipController()
    {
        if (rigidbody.velocity.x > 0 && !facingRight)
            Flip();
        else if (rigidbody.velocity.x < 0 && facingRight)
            Flip();
    }
}