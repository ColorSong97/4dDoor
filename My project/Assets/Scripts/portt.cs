using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portt : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager.instance.currency = 0;
        }
    }
}
