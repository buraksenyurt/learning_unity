
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
        : base(player, playerStateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 1f;
        _player.SetVelocity(5 * -_player.FaceDirection, _player.JumpForce);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log($"{stateTimer}");
        stateTimer -= 0.1f;
        if (stateTimer < 0)
        {
            _playerStateMachine.ChangeState(_player.AirState);
        }

        if (_player.IsGroundDetected())
        {
            _playerStateMachine.ChangeState(_player.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
