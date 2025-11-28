using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyReward : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerManager.instance.currency = 1;
        }
    }

    private void Awake()
    {
        Texture2D texture = GetComponent<SpriteRenderer>().sprite.texture;
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
    }

    private float angle = 0;
    private void Update()
    {
        if (PlayerManager.instance.currency == 1)
            Destroy(gameObject);
        
        transform.localScale = new Vector3(10 * math.cos(angle), transform.localScale.y, transform.localScale.z);
        angle += math.PI * Time.deltaTime / 2f;
    }
}
