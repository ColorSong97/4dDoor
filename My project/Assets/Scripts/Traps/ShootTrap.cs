using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrap : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float existTime;
    private float timer;
    Transform trap;

    public void Start()
    {
        trap = transform.GetChild(0);
    }

    public void Update()
    {
        trap.localPosition = new Vector3(0, timer * speed, 0);
        
        timer += Time.deltaTime;
        if (timer >= existTime)
        {
            timer = 0;
        }
    }
}
