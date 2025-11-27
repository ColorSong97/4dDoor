using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�Ϳ�״̬����ǿ������
public class PlayerApexState : PlayerState
{
    public PlayerApexState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    private float apexTimer;
    public override void Enter()
    {
        base.Enter();
        // Debug.Log("ApexEnter");
        
        apexTimer=player.apexTimeDelay;
    }

    public override void Exit()
    {
        base.Exit();
        // Debug.Log("ApexQuit");
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
        player.rb.velocity = new Vector3(player.moveSpeed * 0.8f * xInput,0);
    }
}
