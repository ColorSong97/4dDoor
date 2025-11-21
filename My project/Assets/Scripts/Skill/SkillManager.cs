using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    public DashSkill dush { get; private set; }
    public CloneSkill clone { get; private set; }




    [Header("SkillLock")]
    [SerializeField] public bool canDush = false;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        dush=GetComponent<DashSkill>();
        clone=GetComponent<CloneSkill>();
    }
    public void UnLockDush()
    {
        canDush=true;
    }
}
