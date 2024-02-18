using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _playerStateMachine;
    protected float xInput;
    protected Player _player;
    protected Rigidbody2D RigiBody;
    private string _animBoolName;
    public PlayerState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
    {
        _playerStateMachine = playerStateMachine;
        _player = player;
        _animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        //Debug.Log($"Enter the {_animBoolName}");
        _player.Anim.SetBool(_animBoolName, true);
        RigiBody = _player.RigiBody;
    }
    public virtual void Update()
    {
        //Debug.Log($"in the {_animBoolName}");
        xInput = Input.GetAxisRaw("Horizontal");
    }

    public virtual void Exit()
    {
        //Debug.Log($"Exit form the {_animBoolName}");
        _player.Anim.SetBool(_animBoolName, false);
    }
}
