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
        // Debug.Log("Ground");
    }

    public override void Exit()
    {
        base.Exit();
        // Debug.Log("Ground Quit");
        
        player.isReadyToJump = false;//������������á��Ϳ������Ļ���
    }
    public override void Update()
    {
        base.Update();
        if (player.isReadyToJump) {//���崥��
            stateMachine.ChangeState(player.jumpState);
            return;
        }
        if (player.isAimPressed && SkillManager.instance.spaceDoor.CanUseSkill()) {
            stateMachine.ChangeState(player.aimState);
            return;
        }

        if (player.isJumpPressed && player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.jumpState);
            return;
        }
        if (!player.IsGroundDetected())
        {
            player.coyoteJudge = true;//�뿪�������������ͬ����Ծ����������
            stateMachine.ChangeState(player.fallState);
            return;
        }
    }
}
