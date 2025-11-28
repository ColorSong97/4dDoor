using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineTrap : MonoBehaviour
{
    public int currentScene;
    public Vector2 position;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.instance.myLoadScene(currentScene, position);
        }
    }
}
