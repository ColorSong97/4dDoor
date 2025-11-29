using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChangeSceneState : PlayerState
{
    Vector3 _position = new Vector3(0, 0, 0);
    
    public PlayerChangeSceneState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }
    
    private float Timer = 0;
    private float Timer2 = 0.5f;

    public override void Update()
    {
        base.Update();
        
        player.transform.position = _position;
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            if (player.IsGroundDetected())
                player.stateMachine.ChangeState(PlayerManager.instance.player.idleState);
            else
            {
                player.stateMachine.ChangeState(PlayerManager.instance.player.fallState);
                player.fallState.coyoteJumpTimer = 0f;
            }
        }
        else if (Timer > 0.4f)
        {
        }
    }

    public override void Enter()
    {
        base.Enter();
        
        Timer = Timer2;
    }

    public override void Exit()
    {
        base.Exit();
        SkillManager.instance.dash.SkillCooldownReset();
        SkillManager.instance.clone.SkillCooldownReset();
        SkillManager.instance.spaceDoor.SkillCooldownReset();
    }

    public void Transport(Vector2 _pos)
    {
        _position = new Vector3(_pos.x, _pos.y, 0);
    }
}
