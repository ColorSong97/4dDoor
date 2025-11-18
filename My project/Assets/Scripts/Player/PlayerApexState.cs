using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//滞空状态，增强操作性
public class PlayerApexState : PlayerState
{
    public PlayerApexState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    private float apexTimer;
    public override void Enter()
    {
        base.Enter();
        apexTimer=player.apexTimeDelay;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        apexTimer -= dTime;
        if (apexTimer > 0) {
            XMOve();
        }
        else
        {
            stateMachine.ChangeState(player.fallState);
        }
        
    }
    private void XMOve()
    {
        if (xInput != 0)
        {
            player.moveSpeed = player.maxMoveSpeed * 0.8f * xInput;
            player.movement = new Vector3(player.moveSpeed, 0, 0);
        }
        else
        {
            player.movement = Vector3.zero;
        }
    }
}
