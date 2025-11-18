using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    private bool isLooseSpace;
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Jump");
        //AudioManager.Instance.PlaySfx(AudioManager.Instance.jumpSfx);
        player.yMoveSpeed = player.jumpForce;
        isLooseSpace = false;
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetFloat("up_down",0);
        player.movement = Vector3.zero;
        Debug.Log("jump Quit");
    }

    public override void Update()
    {
        base.Update();
        player.anim.SetFloat("up_down", player.yMoveSpeed);
        dTime = Time.deltaTime;
        YMove();
        XMOve();
        player.rb.velocity = player.movement + player.yMovement;


        if (player.IsHeadDetected())//碰头了
        {                       
             stateMachine.ChangeState(player.fallState);
             return;
            
        }
        if (player.yMoveSpeed <= 0)
        {
            stateMachine.ChangeState(player.apexState);
        }
    }

    private void XMOve()
    {
        if (xInput != 0)//空中控制权,逻辑简单一点，不向地面那样添加水平阻力，不然我感觉手感有点奇怪
        {
            player.moveSpeed = player.maxMoveSpeed * 0.6f* xInput;
            player.movement = new Vector3(player.moveSpeed ,0,0);
        }
        else
        {
            player.movement = Vector3.zero;
        }
    }

    private void YMove()
    {
        if (Input.GetKey(KeyCode.Space) && !isLooseSpace)//长按跳的高->减速减得慢
        {
            player.yMoveSpeed -= player.gravity * player.yAnitSpeedFactor*dTime;
        }
        else
        {
            isLooseSpace = true;
            player.yMoveSpeed -= player.gravity*dTime;
        }
        player.yMoveSpeed = Mathf.Max(-player.maxFallSpeed, player.yMoveSpeed);
        player.yMovement = new Vector3(0, player.yMoveSpeed,0);
    }
}
