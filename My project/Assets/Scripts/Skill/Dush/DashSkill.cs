using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    public override bool CanUseSkill()
    {

        if (SkillManager.instance.canDash && base.CanUseSkill())
            return true;
        return false;
    }

    public override void UseSkill()
    {
        base.UseSkill();
    }
}
