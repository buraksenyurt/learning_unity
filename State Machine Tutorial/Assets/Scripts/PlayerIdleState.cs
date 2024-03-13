using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
        : base(player, playerStateMachine, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _player.SetVelocityToZero();
    }

    public override void Update()
    {
        base.Update();

        if (xInput == _player.FaceDirection && _player.IsWallDetected())
        {
            return;
        }

        if (xInput != 0 && !_player.IsOnAttacking)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _player.StateMachine.ChangeState(_player.RunState);
            }
            else
            {
                _player.StateMachine.ChangeState(_player.WalkState);
            }
        }


    }

    public override void Exit()
    {
        base.Exit();
    }
}