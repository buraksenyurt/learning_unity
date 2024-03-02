using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
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

        if (_player.IsGroundDetected())
        {
            _player.StateMachine.ChangeState(_player.IdleState);
        }
        if (_player.IsWallDetected())
        {
            _player.StateMachine.ChangeState(_player.WallSlideState);
        }
        if (xInput != 0)
        {
            // Debug.Log($"Current State is, {_playerStateMachine.CurrentState.Name}");
            _player.SetVelocity(_player.WalkSpeed * .75f * xInput, RigiBody.velocity.y);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
