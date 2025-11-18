using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("move");
    }

    public override void Exit()
    {
        base.Exit();
        player.movement = Vector3.zero;
        Debug.Log("move Quit");
    }

    public override void Update()
    {
        base.Update();
        dTime = Time.deltaTime;
        playerMove();
        if (Mathf.Abs(player.moveSpeed) <0.01)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
    private void playerMove()//Ë®Æ½ÒÆ¶¯
    {
        if (xInput != 0)
        {
            player.moveSpeed += player.accSpeed *dTime * xInput;
            player.moveSpeed = player.moveSpeed > player.maxMoveSpeed ? player.maxMoveSpeed:player.moveSpeed;
            player.moveSpeed = player.moveSpeed < -player.maxMoveSpeed ? -player.maxMoveSpeed : player.moveSpeed;
            player.movement = new Vector3(player.moveSpeed, 0,0);
            player.rb.velocity = player.movement;
        }
        else
        {
            player.faceDir = player.moveSpeed > 0 ? 1 : -1;
            player.moveSpeed-=player.anitAccSpeed* dTime * player.faceDir;
            player.movement = new Vector3(player.moveSpeed, 0,0);
            player.rb.velocity=player.movement;
        } 
    }
}
