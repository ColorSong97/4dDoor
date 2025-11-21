using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockDush : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            SkillManager.instance.UnLockDush();
            Destroy(gameObject);
        }
    }
}
