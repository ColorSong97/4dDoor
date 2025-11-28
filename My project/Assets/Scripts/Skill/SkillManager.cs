using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour, ISavingManager
{
    public static SkillManager instance;

    public DashSkill dash { get; private set; }
    public CloneSkill clone { get; private set; }
    public SpaceDoorSkill spaceDoor { get; private set; }



    [Header("SkillLock")]
    [SerializeField] public bool canDash = false;
    [SerializeField] public bool canClone = false;
    [SerializeField] public bool canOpenSpaceDoor = false;

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
        dash=GetComponent<DashSkill>();
        clone=GetComponent<CloneSkill>();
        spaceDoor=GetComponent<SpaceDoorSkill>();
    }
    public void UnLockDush()
    {
        canDash=true;
        UIManager.instance.SetUIWork(3);
    }
    public void UnLockClone()
    {
        canClone=true;
        UIManager.instance.SetUIWork(2);
    }
    public void UnLockSpaceDoor()
    {
        canOpenSpaceDoor=true;
        UIManager.instance.SetUIWork(1);
    }

    
    public void LoadData(GameData _data)
    {
        foreach (KeyValuePair<string,int> pair in _data.inventory)
        {
            if (pair.Key == "canDash" && pair.Value == 1)
            {
                SkillManager.instance.UnLockDush();
                // Debug.Log("dash loaded " + pair.Key + " : " + pair.Value);
            }
            if (pair.Key == "canClone" && pair.Value == 1)
            {
                SkillManager.instance.UnLockClone();
                // Debug.Log("clone loaded " + pair.Key + " : " + pair.Value);
            }
            if (pair.Key == "canOpenSpaceDoor" && pair.Value == 1)
            {
                SkillManager.instance.UnLockSpaceDoor();
                // Debug.Log("open space door loaded " + pair.Key + " : " + pair.Value);
            }
        }
    }

    public void SaveData(ref GameData _data)
    {
        // _data.inventory.Clear();
        
        // use [key] method, autoly cover if key exited
        _data.inventory["canDash"] = canDash ? 1 : 0;
        _data.inventory["canClone"] = canClone ? 1 : 0;
        _data.inventory["canOpenSpaceDoor"] = canOpenSpaceDoor ? 1 : 0;
    
        // Debug.Log($"dash saved: {_data.inventory["canDash"]}");
        // Debug.Log($"clone saved: {_data.inventory["canClone"]}");
        // Debug.Log($"open space door saved: {_data.inventory["canOpenSpaceDoor"]}");
    }
}
