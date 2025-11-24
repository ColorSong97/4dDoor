using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image cooldownMask;
    [SerializeField] private float cooldownDuration;
    [SerializeField] private bool needSkillReadySfx;
    private bool hasPlayReadySfx;
    private float cooldownTimer;


    private void Start()
    {
        cooldownMask.fillAmount = 0;
        cooldownTimer=cooldownDuration;
    }
    private void Update()
    {
        
        cooldownTimer-= Time.deltaTime;
        cooldownTimer=cooldownTimer<=0? 0: cooldownTimer ;
        if (!hasPlayReadySfx &&needSkillReadySfx&& cooldownTimer == 0)
        {
            hasPlayReadySfx = true;
            AudioManager.Instance.PlaySfx(AudioManager.Instance.SkillReadySfx);
        }
        float fillRatio= cooldownTimer/cooldownDuration ;
        cooldownMask.fillAmount=fillRatio;
    }
    public void OnSkillUse()
    {
        cooldownTimer = cooldownDuration;
        cooldownMask.fillAmount = 1;
        hasPlayReadySfx=false;
    }
}
