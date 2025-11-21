using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : Skill
{
    [SerializeField] private GameObject clonePrefab;

    public void CreatClone()
    {
        GameObject newclone=Instantiate(clonePrefab);
    }
}
