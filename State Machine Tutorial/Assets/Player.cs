using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Info")]
    public float WalkSpeed = 4f;
    public float RunSpeed = 10f;
    public float JumpForce;

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

    #endregion

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        WalkState = new PlayerWalkState(this, StateMachine, "Walk");
        RunState = new PlayerRunState(this, StateMachine, "Run");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
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
    }

}
