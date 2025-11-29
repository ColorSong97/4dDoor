using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripts : MonoBehaviour
{
    public void Start()
    {
        
    }

    public void Update()
    {
        transform.position = new Vector3(PlayerManager.instance.player.transform.position.x, PlayerManager.instance.player.transform.position.y, transform.position.z);
    }
}
