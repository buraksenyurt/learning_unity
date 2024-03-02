public class PlayerBaseAttackState : PlayerState
{
    public PlayerBaseAttackState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
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
        if (triggerCalled)
        {
            _playerStateMachine.ChangeState(_player.IdleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
