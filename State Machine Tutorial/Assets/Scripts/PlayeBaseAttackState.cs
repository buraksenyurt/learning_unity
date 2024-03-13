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
        _player.Anim.speed = 1.1f;

        float attackDirection = _player.FaceDirection;
        if (xInput != 0)
        {
            attackDirection = xInput;
        }

        _player.SetVelocity(_player.AttackMovement[comboAttackCounter].x * attackDirection
                            , _player.AttackMovement[comboAttackCounter].y);

        stateTimer = 0.1f;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
            _player.SetVelocityToZero();

        if (triggerCalled)
            _playerStateMachine.ChangeState(_player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();

        _player.StartCoroutine("BusyForAttacking", 0.2f);
        _player.Anim.speed = 1;
        comboAttackCounter++;
        lastTimeAttacked = Time.time;
    }
}
