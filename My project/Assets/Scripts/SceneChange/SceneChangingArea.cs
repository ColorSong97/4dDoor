using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SceneChangingArea : MonoBehaviour
{
    [SerializeField] private int nextRoom;
    [SerializeField] private Vector2 transportPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("scene changing area entered");
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.instance.myLoadScene(nextRoom, transportPosition);
        }
    }
}
