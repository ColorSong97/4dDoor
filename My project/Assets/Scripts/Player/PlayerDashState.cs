using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    private float Timer;
    public override void Enter()
    {
        base.Enter();
        // Debug.Log("DashEnter");
        
        AudioManager.Instance.PlaySfx(AudioManager.Instance.DashSfx);
        Timer=player.dushTime;
    }

    public override void Exit()
    {
        base.Exit();
        // Debug.Log("DashQUit");
    }

    public override void Update()
    {
        base.Update();
        
        Timer -= dTime;
        
        if (Timer > 0)
        {
            player.rb.velocity = new Vector2(player.dushSpeed * player.faceDir, 0);
        }
        else
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
