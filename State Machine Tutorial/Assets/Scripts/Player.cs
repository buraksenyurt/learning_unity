using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Attack Details")]
    public Vector2[] AttackMovement;

    [Header("Movement Info")]
    public float WalkSpeed = 4f;
    public float RunSpeed = 10f;
    public float JumpForce;

    [Header("Collision Info")]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private float GroundCheckDistance;
    [SerializeField] private Transform WallCheck;
    [SerializeField] private float WallCheckDistance;
    [SerializeField] private LayerMask WhatIsGround;

    public int FaceDirection { get; private set; } = 1;
    private bool FacingRight = true;
    public bool IsOnAttacking { get; private set; }

    #region Components
    public Animator Anim { get; private set; }
    public Rigidbody2D RigiBody { get; private set; }

    #endregion

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerBaseAttackState BaseAttackState { get; private set; }

    #endregion

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        WalkState = new PlayerWalkState(this, StateMachine, "Walk");
        RunState = new PlayerRunState(this, StateMachine, "Run");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, "WallSlide");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, "WallJump");
        BaseAttackState = new PlayerBaseAttackState(this, StateMachine, "Attack");
    }
    private void Start()
    {
        RigiBody = GetComponent<Rigidbody2D>();
        Anim = GetComponentInChildren<Animator>();
        StateMachine.Initialize(IdleState);
    }
    private void Update()
    {
        StateMachine.CurrentState.Update();
    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        RigiBody.velocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(GroundCheck.position, new Vector3(GroundCheck.position.x, GroundCheck.position.y - GroundCheckDistance));
        Gizmos.DrawLine(WallCheck.position, new Vector3(WallCheck.position.x + WallCheckDistance, WallCheck.position.y));
    }

    public void Flip()
    {
        FaceDirection *= -1;
        FacingRight = !FacingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float xValue)
    {
        if (xValue > 0 && !FacingRight)
            Flip();
        else if (xValue < 0 && FacingRight)
            Flip();
    }

    public bool IsGroundDetected() => Physics2D.Raycast(GroundCheck.position, Vector2.down, GroundCheckDistance, WhatIsGround);
    public bool IsWallDetected() => Physics2D.Raycast(WallCheck.position, Vector2.right * FaceDirection, WallCheckDistance, WhatIsGround);
    public void TriggerAnimation() => StateMachine.CurrentState.AnimationFinishTrigger();
    public IEnumerator BusyForAttacking(float seconds)
    {
        IsOnAttacking = true;
        yield return new WaitForSeconds(seconds);
        IsOnAttacking = false;
    }

    public void SetVelocityToZero() => RigiBody.velocity = new Vector2(0, 0);
}
