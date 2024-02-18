using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
        : base(player, playerStateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        RigiBody.velocity = new Vector2(RigiBody.velocity.x, _player.JumpForce);
    }

    public override void Update()
    {
        base.Update();
        if (RigiBody.velocity.y < 0)
        {
            _player.StateMachine.ChangeState(_player.AirState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
