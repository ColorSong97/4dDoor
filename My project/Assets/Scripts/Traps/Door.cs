using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public void Update()
    {
        if (PlayerManager.instance.currency == 0)
        {
            transform.localScale = new Vector3(10, 2, 1);
        }
        else if (PlayerManager.instance.currency == 1)
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
