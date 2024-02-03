using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine _playerStateMachine;
    protected Player _player;
    private string _animBoolName;
    public PlayerState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
    {
        _playerStateMachine = playerStateMachine;
        _player = player;
        _animBoolName = animBoolName;
    }
    public virtual void Enter()
    {
        Debug.Log($"Enter the {_animBoolName}");
    }
    public virtual void Update()
    {
        Debug.Log($"in the {_animBoolName}");
    }

    public virtual void Exit()
    {
        Debug.Log($"Exit form the {_animBoolName}");
    }
}
