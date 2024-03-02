using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
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
        if (xInput != 0 && _player.FaceDirection != xInput)
        {
            _playerStateMachine.ChangeState(_player.IdleState);
        }
        if (yInput < 0)
        {
            RigiBody.velocity = new Vector2(0, RigiBody.velocity.y);
        }
        else
        {
            RigiBody.velocity = new Vector2(0, RigiBody.velocity.y * 0.75f);
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
