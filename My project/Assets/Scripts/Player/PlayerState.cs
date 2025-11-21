using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    

    private string animBoolName;
    protected float xInput;
    protected float yInput;

    protected float dTime;
    public PlayerState(Player _player,PlayerStateMachine _stateMachine,string _animBoolName)
    {
        player = _player;
        stateMachine = _stateMachine;
        animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName,true);
    }
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");      
        yInput = Input.GetAxisRaw("Vertical");
        if (xInput != 0)
        {
            player.faceDir = xInput > 0 ? 1 : -1;
        }
        dTime = Time.deltaTime;
    }
    public virtual void Exit() 
    {
        player.anim.SetBool(animBoolName, false);

    }
   
}
