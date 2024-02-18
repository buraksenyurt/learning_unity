using UnityEngine;

public class PlayerRunState : PlayerState
{
    public PlayerRunState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
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

        if (Input.GetKeyDown(KeyCode.R))
            _player.StateMachine.ChangeState(_player.IdleState);

        if (Input.GetKeyDown(KeyCode.W))
            _player.StateMachine.ChangeState(_player.WalkState);
    }

    public override void Exit()
    {
        base.Exit();
    }
}
