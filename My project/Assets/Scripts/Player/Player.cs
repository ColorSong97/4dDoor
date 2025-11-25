using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public SkillManager skill {  get; private set; }
    [Header("Move")]
    public float moveSpeed;//ʵʱ����

    [Header("Jump")]
    public float jumpForce;
    public float downForce;
    public float coyoteJumpForce;
    public float coyoteJumpDelay;//�������
    public bool coyoteJudge;
    public bool canAddCF;
    public bool isReadyToJump;//���������
    public float apexTimeDelay;//�������
    [Header("dush")]
    public float dushSpeed;
    public float dushTime;

    [Header("Collsion")]
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask whatIsGround;
    public int faceDir=1;//1���ң�-1����
    [SerializeField] private Transform jumpBufferCheck;
    [SerializeField] private float jumpBufferDistence;
    [SerializeField] private Transform headCheck;
    [SerializeField] private float headCheckDistence;


    [Header("Death")]
    public float yBounds;
    public float DeathDelay;
    public bool isBusy;

    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState {  get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerFallState fallState { get; private set; }
    public PlayerApexState apexState { get; private set; }
    public PlayerDuahState dushState {  get; private set; }
    public PlayerAimDoorState aimState { get; private set; }

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        jumpState = new PlayerJumpState(this, stateMachine, "jump");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        fallState = new PlayerFallState(this, stateMachine, "jump");
        apexState = new PlayerApexState(this, stateMachine, "apex");
        dushState = new PlayerDuahState(this, stateMachine, "dush");
        aimState = new PlayerAimDoorState(this, stateMachine, "aim");
    }

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponentInChildren<Animator>();
        stateMachine.Initialize(idleState);
        skill = SkillManager.instance;
    }

   
    void Update()
    {
        CheckForDush();
        CheckForClone();
        stateMachine.currentState.Update();

    }

    private void CheckForClone()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && SkillManager.instance.clone.CanUseSkill())
        {
            UIManager.instance.cloneCD.OnSkillUse();


            Vector3 dir = rb.velocity.normalized;
            float distance = 1.4f;

            Vector3 clonePos = transform.position - dir * distance;


            SkillManager.instance.clone.CreatClone(clonePos);
        }
    }

    private void CheckForDush()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.instance.dush.CanUseSkill())
        {
            UIManager.instance.dashCD.OnSkillUse();
            stateMachine.ChangeState(dushState);
        }
    }


    public bool IsGroundDetected() => Physics2D.CircleCast(groundCheck.position,groundCheckRadius, Vector2.down, 0, whatIsGround);
    public bool IsHeadDetected() => Physics2D.Raycast(headCheck.position, Vector2.up, headCheckDistence, whatIsGround);

    public bool IsJBAble() => Physics2D.Raycast(jumpBufferCheck.position, Vector2.down, jumpBufferDistence, whatIsGround);
    private void OnDrawGizmos()//���ݻ��ߵ���һ�¼��λ�ã����ǹ���
    {
        Gizmos.DrawWireSphere(groundCheck.position,groundCheckRadius);
        Gizmos.DrawLine(jumpBufferCheck.position,
            new Vector3(jumpBufferCheck.position.x, jumpBufferCheck.position.y - jumpBufferDistence, jumpBufferCheck.position.z));
        Gizmos.DrawLine(headCheck.position,
            new Vector3(headCheck.position.x, headCheck.position.y + headCheckDistence, headCheck.position.z));

    }
    public IEnumerator Death(float seconds)
    {
       
        yield return new WaitForSeconds(seconds);
        //û��gameManager��������ע�͵������������ж�Ҳ�ø�
        //GameManager.Instance.ReLoad();
        //GameManager.Instance.DeadAdd();
    }
    public void DieCheck()
    {
        if (transform.position.y <yBounds)
        {
            _ = StartCoroutine(Death(DeathDelay));   
            return;
        }
    }
}
