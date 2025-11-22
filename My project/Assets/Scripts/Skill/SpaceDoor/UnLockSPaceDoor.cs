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
            Destroy(gameObject);
        }
    }
}
