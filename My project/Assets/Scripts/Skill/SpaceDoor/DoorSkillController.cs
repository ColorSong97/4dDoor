using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSkillController : MonoBehaviour
{
    private  Animator anim;
    [SerializeField]private GameObject door1, door2;
    private Player player;

    private float Timer;
    [SerializeField]private float DisAppearTime;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        player = PlayerManager.instance.player;
    }
    private void Start()
    {
        Timer = DisAppearTime;
        anim.SetBool("rotate", true);
    }
    protected virtual void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            DoorClose();
        }
    }
    public void SetupDoor(Vector2 _dir)
    {
        Vector2 dir = _dir.normalized;
        Vector3 offset1 = new Vector3(dir.x * 1.5f, dir.y * 1.5f, 0);
        Vector3 offset2 = new Vector3(_dir.x, _dir.y, 0);
        door1.transform.position= player.transform.position+offset1;
        door2.transform.position= player.transform.position + offset2;
    }
    public void DoorClose()
    {
        anim.SetBool("rotate", false);


    }
    public void DeleteDoor()
    {
        Destroy(gameObject);
    }

}
