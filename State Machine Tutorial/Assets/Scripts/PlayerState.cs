using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _playerStateMachine;
    protected float xInput;
    protected float yInput;
    protected float stateTimer;
    protected bool triggerCalled;
    protected Player _player;
    protected Rigidbody2D RigiBody;
    private string _animBoolName;
    public string Name;
    public PlayerState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
    {
        _playerStateMachine = playerStateMachine;
        _player = player;
        _animBoolName = animBoolName;
        Name = animBoolName;
    }
    public virtual void Enter()
    {
        //Debug.Log($"Enter the {_animBoolName}");
        _player.Anim.SetBool(_animBoolName, true);
        RigiBody = _player.RigiBody;
        triggerCalled = false;
    }
    public virtual void Update()
    {
        //Debug.Log($"in the {_animBoolName}");
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        _player.Anim.SetFloat("yVelocity", RigiBody.velocity.y);
        //Debug.Log(_player.Anim.GetFloat("yVelocity").ToString());
    }

    public virtual void Exit()
    {
        //Debug.Log($"Exit form the {_animBoolName}");
        _player.Anim.SetBool(_animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
