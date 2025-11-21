using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkillController : MonoBehaviour
{
    private SpriteRenderer sr;

    private float colorLosenSpeed; 
    private float cloneTimer;
    private void Awake()
    {
        sr=GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float dT = Time.deltaTime;
        cloneTimer -= dT;
        if (cloneTimer < 0)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - (dT * colorLosenSpeed));

        }
        if (sr.color.a <= 0.05)
        {
            Destroy(gameObject);
        }
    }



    public void SetupClone(Vector3 _newTransform,float _cloneDuration,float _colorLoseSpeed)
    {
        transform.position= _newTransform;
        colorLosenSpeed = _colorLoseSpeed;
        cloneTimer = _cloneDuration;
    }
}
