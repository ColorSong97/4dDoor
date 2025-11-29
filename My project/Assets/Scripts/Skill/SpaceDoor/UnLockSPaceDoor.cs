using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockSPaceDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SkillManager.instance.UnLockSpaceDoor();
        }
    }

    public void Update()
    {
        if (SkillManager.instance.canOpenSpaceDoor)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
