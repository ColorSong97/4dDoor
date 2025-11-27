using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimDoorState : PlayerState
{
    public PlayerAimDoorState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // Debug.Log("AimEnter");
        
        player.skill.spaceDoor.DotActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        // Debug.Log("aimQuit");
    }

    public override void Update()
    {
        base.Update();
        
        if (player.isAimReleased)
        {
            UIManager.instance.spaceCD.OnSkillUse();
            SkillManager.instance.spaceDoor.CreatDoor();
            AudioManager.Instance.PlaySfx(AudioManager.Instance.SpaceDoorSkillSfx);
            
            stateMachine.ChangeState(player.idleState);
        }
    }
}
