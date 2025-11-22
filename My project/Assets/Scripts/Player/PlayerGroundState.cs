using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Ground");
    }

    public override void Exit()
    {
        base.Exit();
        player.isReadyToJump = false;//脱离地面后就重置“滞空跳”的缓冲
        Debug.Log("Ground Quit");
    }
    public override void Update()
    {
        base.Update();
        if (player.isReadyToJump) {//缓冲触发
            stateMachine.ChangeState(player.jumpState);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)&&SkillManager.instance.spaceDoor.CanUseSkill()) {
            stateMachine.ChangeState(player.aimState);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }
        if (!player.IsGroundDetected())
        {
            player.coyoteJudge = true;//离开地面空中起跳不同于跳跃后下落起跳
            stateMachine.ChangeState(player.fallState);
            return;
        }
    }
}
