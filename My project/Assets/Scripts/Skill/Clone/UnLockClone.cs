using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnLockClone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SkillManager.instance.UnLockClone();
            Destroy(gameObject);
        }
    }
}
