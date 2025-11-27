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
        // Debug.Log("move");
    }

    public override void Exit()
    {
        base.Exit();
        // Debug.Log("move Quit");
    }

    public override void Update()
    {
        base.Update();
        player.rb.velocity = new Vector2(player.moveSpeed * xInput, player.rb.velocity.y);
        if (xInput == 0)
            stateMachine.ChangeState(player.idleState);

    }
}
