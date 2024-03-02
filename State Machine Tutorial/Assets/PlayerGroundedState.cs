using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
        : base(player, playerStateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.S))
        {
            _playerStateMachine.ChangeState(_player.BaseAttackState);
        }
        if (!_player.IsGroundDetected())
        {
            _player.StateMachine.ChangeState(_player.AirState);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _player.IsGroundDetected())
            _player.StateMachine.ChangeState(_player.JumpState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}