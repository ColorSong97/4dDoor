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
        player.coyoteJudge = false;//下落结束，把这个参数改了

        player.yMovement = Vector3.zero;
        Debug.Log("fallQuit");
    }

    public override void Update()
    {
        base.Update();
        dTime = Time.deltaTime;
        coyoteJumpTimer -= dTime;
        player.anim.SetFloat("up_down", player.yMoveSpeed);
        if (CoyoteJump())
        {
            return;
        }
        
        XMOve();
        YMove();
        player.rb.velocity = player.movement + player.yMovement;
        if (player.IsGroundDetected())
        {
            //AudioManager.Instance.PlaySfx(AudioManager.Instance.fallLandSfx);
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
            if (coyoteJumpTimer >= 0 && player.coyoteJudge)//狼跳
            {
                stateMachine.ChangeState(player.jumpState);
                return true;
            }
            if (player.IsJBAble())
            {
                player.isReadyToJump = true;//如果不是狼跳，这里预备下落缓冲起跳   
            }
        }
        return false;
    }

    private void XMOve()
    {
        if (xInput != 0)//空中控制权,逻辑简单一点，不向地面那样添加水平阻力，不然我感觉手感有点奇怪
        {
            player.moveSpeed = player.maxMoveSpeed * 0.6f * xInput;
            player.movement = new Vector3(player.moveSpeed , 0,0);
        }
        else
        {
            player.movement = Vector3.zero;
        }
    }
    private void YMove()
    {
       
        player.yMoveSpeed -=player.gravity*dTime;
        if(player.yMoveSpeed < 0)
            player.yMoveSpeed=Mathf.Max(-player.maxFallSpeed,player.yMoveSpeed);
        player.yMovement = new Vector3(0, player.yMoveSpeed,0);
    }
}
