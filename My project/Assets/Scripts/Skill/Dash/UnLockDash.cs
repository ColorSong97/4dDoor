using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockDash : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            SkillManager.instance.UnLockDush();
            Destroy(gameObject);
        }
    }
}
