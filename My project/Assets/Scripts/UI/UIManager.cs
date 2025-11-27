using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public static UIManager instance;


    [Header("SkillCoolDownInfo")]
    [SerializeField] GameObject SpaceSCDUI;
    public CDUI spaceCD;
    [SerializeField] GameObject CloneSCDUI;
    public CDUI cloneCD;
    [SerializeField] GameObject DashSCDUI;
    public CDUI dashCD;
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
        spaceCD = SpaceSCDUI.GetComponent<CDUI>();
        cloneCD = CloneSCDUI.GetComponent<CDUI>();
        dashCD = DashSCDUI.GetComponent<CDUI>();
    }
    public void SetUIWork(int i)
    {
        if (i == 1) { SpaceSCDUI.SetActive(true); return; }
        if (i == 2) { CloneSCDUI.SetActive(true); return; }
        if (i == 3) { DashSCDUI.SetActive(true); return; }
        AudioManager.Instance.PlaySfx(AudioManager.Instance.GainSkillSfx);
        return;
    }

    public void BackToMain()
    {
        SceneManager.instance.myMenuScene();
    }


}
