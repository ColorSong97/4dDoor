using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpaceDoorSkill : Skill
{
    [Header("SkillInfo")]
    [SerializeField] private GameObject spaceDoorPrefab;
    [SerializeField] private float doorDistance=1f;
    [SerializeField] private LayerMask whatIsGround;
    private Vector2 finalDir;

    [Header("Aim Dots")]
    [SerializeField] private int numOfDots;
    [SerializeField] private float spaceBeetwentDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotsParent;

    private GameObject[] dots;

    protected override void Start()
    {
        base.Start();
        GenerateDots();
    }
    protected override void Update()//依据鼠标右键更新方向
    {
        base.Update();
       
           
        finalDir=AimDirection().normalized*doorDistance;

        RaycastHit2D hit= Physics2D.Raycast(player.transform.position, finalDir, doorDistance, whatIsGround);
        if (hit) {
            Vector2 hitPoint= hit.point;
            finalDir=new Vector2(hitPoint.x-player.transform.position.x,hitPoint.y-player.transform.position.y);              
        }
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            for (int i = 0; i < numOfDots; i++)
            {
                dots[i].transform.position = DotsPositon(i * spaceBeetwentDots);
            }
        }
    }
    public void CreatDoor()
    {
       
        GameObject spaceDoor =Instantiate(spaceDoorPrefab, player.transform.position,transform.rotation);

        DoorSkillController newSpacePairDoor=spaceDoor.GetComponent<DoorSkillController>();

        newSpacePairDoor.SetupDoor(finalDir);

        DotActive(false);
    }
    public Vector2 AimDirection()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 dir=mousePosition- playerPosition;
        return dir;
    }


    public void DotActive(bool _isAct)
    {
        for (int i = 0; i < numOfDots; i++)
        {
            dots[i].SetActive(_isAct);
        }
    }
    private void GenerateDots()
    {
        dots = new GameObject[numOfDots];
        for (int i = 0; i < numOfDots; ++i)
        {
            dots[i]=Instantiate(dotPrefab,player.transform.position,Quaternion.identity,dotsParent);
            dots[i].SetActive(false);
        }
    }
    private Vector2 DotsPositon(float t)
    {
        Vector2 position=(Vector2)player.transform.position+finalDir*t;
        return position;
    }
    public override bool CanUseSkill()
    {
        if (SkillManager.instance.canOpenSpaceDoor && base.CanUseSkill())
            return true;
        return false;
    }
}
