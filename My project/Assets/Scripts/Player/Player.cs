using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    [Header("Move")]
    public float moveSpeed;//实时移速
    public float maxMoveSpeed;
    public float accSpeed;
    public float anitAccSpeed;
    public Vector3 movement;//移动向量

    [Header("Jump")]
    public float yMoveSpeed;
    public Vector3 yMovement;
    public float yAnitSpeedFactor;//奇妙的小因子
    public float jumpForce;//瞬时爆发
    public float gravity;
    public float maxFallSpeed;//下移恒定比较好操作判断,这里不再使用加速度
    public float coyoteJumpDelay;//狼跳组件
    public bool coyoteJudge;
    public bool isReadyToJump;//缓冲跳组件
    public float apexTimeDelay;//悬空组件

    [Header("Collsion")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistence;
    [SerializeField] private LayerMask whatIsGround;
    public int faceDir;//1是右，-1是左
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
    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "idle");
        jumpState = new PlayerJumpState(this, stateMachine, "jump");
        moveState = new PlayerMoveState(this, stateMachine, "move");
        fallState = new PlayerFallState(this, stateMachine, "jump");
        apexState = new PlayerApexState(this, stateMachine, "apex");
    }

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        anim=GetComponentInChildren<Animator>();
        stateMachine.Initialize(idleState);
    }

   
    void Update()
    {
        DieCheck();
        stateMachine.currentState.Update();
        
    }
  


    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistence, whatIsGround);
    public bool IsHeadDetected() => Physics2D.Raycast(headCheck.position, Vector2.up, headCheckDistence, whatIsGround);

    public bool IsJBAble() => Physics2D.Raycast(jumpBufferCheck.position, Vector2.down, jumpBufferDistence, whatIsGround);
    private void OnDrawGizmos()//根据画线调整一下检测位置，算是工具
    {
        Gizmos.DrawLine(groundCheck.position,
            new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistence, groundCheck.position.z));
        Gizmos.DrawLine(jumpBufferCheck.position,
            new Vector3(jumpBufferCheck.position.x, jumpBufferCheck.position.y - jumpBufferDistence, jumpBufferCheck.position.z));
        Gizmos.DrawLine(headCheck.position,
            new Vector3(headCheck.position.x, headCheck.position.y + headCheckDistence, headCheck.position.z));

    }
    public IEnumerator Death(float seconds)
    {
       
        yield return new WaitForSeconds(seconds);
        //没有gameManager，这里先注释掉，而且死亡判定也得改
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
