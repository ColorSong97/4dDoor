using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSkill : Skill
{
    [Header("clone info")]
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;
    [SerializeField] private float colorLosenSpeed;
    public override bool CanUseSkill()
    {
        if (SkillManager.instance.canClone && base.CanUseSkill())
            return true;
        return false;
    }

    public void CreatClone(Vector3 _clonePosition)
    {
        GameObject newclone=Instantiate(clonePrefab);
        newclone.GetComponent<CloneSkillController>().SetupClone(_clonePosition,cloneDuration,colorLosenSpeed);
    }
}
