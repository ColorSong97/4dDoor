using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, ISavingManager
{
    public static PlayerManager instance;
    public Player player;

    public int currency;
    private float unmoveableTimer = 0;
    
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (unmoveableTimer > 0)
            unmoveableTimer -= Time.deltaTime;
        else
            unmoveableTimer = 0;
        MyInput();
    }

    public void setUnmoveableTimer(float timer)
    {
        unmoveableTimer = timer;
        
        player.InputMove(0);
        player.InputJump(false);
        player.InputDash(false);
        player.InputClone(false);
        player.InputAim(false);
        player.InputAimReleased(false);
    }

    public void MyInput()
    {
        if (unmoveableTimer > 0)    // do not catch inputs
        {
            return;
        }

        // get a&d input
        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.D))
            {
                player.InputMove(0);
            }
            else
            {
                player.InputMove(-1);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.D))
            {
                player.InputMove(1);
            }
            else
            {
                player.InputMove(0);
            }
        }
        player.InputJump(Input.GetKeyDown(KeyCode.Space));      // get jump input
        player.InputDash(Input.GetKeyDown(KeyCode.LeftShift));  // get dash input
        player.InputClone(Input.GetKeyDown(KeyCode.Mouse0));    // get clone input
        player.InputAim(Input.GetKeyDown(KeyCode.Mouse1));      // get space door input
        player.InputAimReleased(Input.GetKeyUp(KeyCode.Mouse1));// get space door released
        
        // Debug.Log("Inputs:" + "\nXInput: " + player.moveVector + "\nJump: " + player.isJumpPressed + "\nDash: " + player.isDashPressed + "\nClone: " + player.isClonePressed + "\nAim: " + player.isAimPressed);
    }
    

    public void LoadData(GameData _data)
    {
        this.currency = _data.currency;
    }

    public void SaveData(ref GameData _data)
    {
        // _data.inventory.Clear();
        
        // _data.currency = this.currency;
    }
}
