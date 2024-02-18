public class PlayerRunState : PlayerGroundedState
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

        _player.SetVelocity(xInput * _player.RunSpeed, RigiBody.velocity.y);

        if (xInput == 0)
        {
            _player.StateMachine.ChangeState(_player.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
