using UnityEngine;
public class PlayerBaseAttackState : PlayerState
{
    private int comboAttackCounter;
    private float lastTimeAttacked;
    private float comboAttackWindow = 2;
    public PlayerBaseAttackState(Player player, PlayerStateMachine playerStateMachine, string animBoolName)
        : base(player, playerStateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (comboAttackCounter > 2 || Time.time >= lastTimeAttacked + comboAttackWindow)
            comboAttackCounter = 0;

        _player.Anim.SetInteger("ComboAttackCounter", comboAttackCounter);
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
        comboAttackCounter++;
        lastTimeAttacked = Time.time;
    }
}
