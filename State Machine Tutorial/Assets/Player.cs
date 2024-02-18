using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator Anim { get; private set; }

    #endregion

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; set; }

    #endregion

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idle");
        WalkState = new PlayerWalkState(this, StateMachine, "Walk");
        RunState = new PlayerRunState(this, StateMachine, "Run");
    }
    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
        StateMachine.Initialize(IdleState);
    }
    private void Update()
    {
        StateMachine.CurrentState.Update();
    }

}
