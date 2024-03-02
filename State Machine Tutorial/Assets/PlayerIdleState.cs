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
        RigiBody.velocity = new Vector2(0, 0);
    }

    public override void Update()
    {
        base.Update();

        if (xInput == _player.FaceDirection && _player.IsWallDetected())
        {
            return;
        }

        if (xInput != 0)
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