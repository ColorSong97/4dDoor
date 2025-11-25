using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerState
{
    public PlayerFallState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    float coyoteJumpTimer;
    
    public override void Enter()
    {
        base.Enter();
        coyoteJumpTimer = player.coyoteJumpDelay;
        Debug.Log("fall");
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetFloat("up_down",0);
        player.coyoteJudge = false;//����������������������
        Debug.Log("fallQuit");
    }

    public override void Update()
    {
        base.Update();
        player.anim.SetFloat("up_down", player.rb.velocity.y);
        coyoteJumpTimer -= dTime;
        if (CoyoteJump())
        {
            return;
        }
        
        XMOve();

        if (player.IsGroundDetected())
        {
            // AudioManager.Instance.PlaySfx(AudioManager.Instance.fallLandSfx);
            if (xInput == 0)
                stateMachine.ChangeState(player.idleState);
            else
            {
                stateMachine.ChangeState(player.moveState);
            }
        }
    }

    private bool CoyoteJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coyoteJumpTimer >= 0 && player.coyoteJudge)//����
            {
                player.canAddCF = true;
                stateMachine.ChangeState(player.jumpState);
                return true;
            }
            if (player.IsJBAble())
            {
                player.isReadyToJump = true;//�����������������Ԥ�����仺������   
            }
        }
        return false;
    }

    private void XMOve()
    {
       //���п���Ȩ,�߼���һ�㣬��������������ˮƽ��������Ȼ�Ҹо��ָ��е����
        
       player.rb.velocity = new Vector3(player.moveSpeed * 0.8f * xInput, player.rb.velocity.y);        

    }
}
