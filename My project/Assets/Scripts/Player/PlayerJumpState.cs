using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        Debug.Log("Jump");

        AudioManager.Instance.PlaySfx(AudioManager.Instance.jumpSfx);
        if (player.canAddCF)
        {
            player.rb.AddForce(Vector2.up * player.coyoteJumpForce, ForceMode2D.Impulse);
            Debug.Log("CoJ");
        }
        else
            player.rb.AddForce(Vector2.up * player.jumpForce, ForceMode2D.Impulse);
    }

    public override void Exit()
    {
        base.Exit();
        player.canAddCF = false;
        player.anim.SetFloat("up_down",0);
        Debug.Log("jump Quit");
    }

    public override void Update()
    {
        base.Update();
        player.anim.SetFloat("up_down", player.rb.velocity.y);
        XMOve();

        if (player.IsHeadDetected())//碰头了
        {                       
             stateMachine.ChangeState(player.fallState);
             player.rb.AddForce(Vector2.down*player.downForce,ForceMode2D.Impulse);
             return;
            
        }
        if (player.rb.velocity.y <= 0)
        {
            stateMachine.ChangeState(player.apexState);
        }
    }

    private void XMOve()
    {
       //空中控制权,逻辑简单一点，不向地面那样添加水平阻力，不然我感觉手感有点奇怪
        
       player.rb.velocity = new Vector3(player.moveSpeed * 0.8f* xInput,player.rb.velocity.y);
    }
}
