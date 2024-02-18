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
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0 && Input.GetKey(KeyCode.W))
        {
            _player.StateMachine.ChangeState(_player.WalkState);
        }
        else if (xInput != 0 && Input.GetKey(KeyCode.R))
        {
            _player.StateMachine.ChangeState(_player.RunState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}