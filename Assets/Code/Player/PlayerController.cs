using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D.IK;

public sealed class PlayerController : MonoBehaviour
{
    #region Properties
    [Header("Movement settings")]
    [Tooltip("Jump force to apply when jumping, not multiplied by Time.deltaTime, so for better results its recommended use low values.")]
    [SerializeField] float jumpForce;
    [Tooltip("Speed ammount to apply when player moves on horizontal, multiplied by Time.deltaTime.")]
    [SerializeField] float speed;
    [Tooltip("The animator of the complete back arm.")]
    [SerializeField]Animator backArmAnimator;
    [Header("Raycast collision settings")]
    [Tooltip("The ground layer to check if raycast collides with him.")]
    [SerializeField] LayerMask groundLayer;
    [Tooltip("Distance to draw the raycast in Vector2.Up direction, to check collision with ground at jump.")]
    [SerializeField] float distanceTop;
    [Tooltip("Distance to draw the raycast in transform.right, to check collision with walls on ground movement.")]
    [SerializeField] float distanceFront;
    [Header("Aim settings")]
    [Tooltip("The sight of the gun to put over the screen.")]
    [SerializeField] Transform mouseSight;
    [Tooltip("Target transform used to move the arm when is aiming on screen.")]
    [SerializeField] Transform frontArmTarget;
    [Tooltip("Target transform used to move the arm when is aiming on screen.")]
    [SerializeField] Transform backArmTarget; 
    [Tooltip("Back arm LimbSolver2D to update the arm target following player aim with two hands gun.")]
    [SerializeField] LimbSolver2D limbSolver2D;
    public Gun gun{get;set;}
    private Rigidbody2D rigid;
    private Animator animator;
    private Camera mainCam;
    private Vector2 mouseSightPosition;
    public Transform secondHandGrab{get;set;}
    public Transform twoHandsGun{get;set;}
    private bool jump, idle, isActivated, movement = true, crouch, onGround, death;
    public bool IsDeath { set => death = value; }
    public bool Movement { set => movement = value; }
    public bool IsGrounded { set => onGround = value; }
    private float xInput;
    private const float timeJumping = .25f;
    public bool IsActivated { get => isActivated; }
    #endregion
    #region Unity Methods
    void Awake()
    {
        mouseSight.SetParent(null);
        mainCam=Camera.main;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        if (movement)
        {
            float xVelo = speed * xInput * Time.deltaTime;
            if (jump) rigid.SetVelocity(xVelo, jumpForce);
            else rigid.SetVelocity(xVelo, rigid.velocity.y);
        }
        else if (death)
        {
            rigid.SetVelocity(0, rigid.velocity.y);
        }
    }
    private void Update()
    {
        if (movement)
        {
            if (!onGround) OnAir();
            else OnGround();
        }
    }
    private void LateUpdate() {
        /*Synchronizes back arm animator and the current body animator.*/
        animator.SetBool("grounded", onGround);
        backArmAnimator.SetBool("grounded",onGround);

        animator.SetBool("onJump",jump);
        backArmAnimator.SetBool("onJump", jump);

        if(onGround){
            animator.SetBool("walk", xInput != 0);
            backArmAnimator.SetBool("walk", xInput != 0);

            animator.SetBool("idle", xInput == 0);
            backArmAnimator.SetBool("idle", xInput == 0);

        }else{
            animator.SetBool("walk", false);
            animator.SetBool("walk", false);

            animator.SetBool("idle", false);
            backArmAnimator.SetBool("idle", false);

        }
    }
    #endregion
    #region On air methods
    /// <summary>
    /// When player is in the air, at jumping or falling, evaluates some interactions.
    /// </summary>
    private void OnAir()
    {
        CheckHeadCollisionOnJumping();
    }
    /// <summary>
    /// Checks if player is colliding with ground over him.
    /// </summary>
    private void CheckHeadCollisionOnJumping()
    {
        if (Physics2D.Raycast(transform.position, Vector2.up, distanceTop, groundLayer))
        {
            jump = false;
        }
    }
    #endregion
    #region On ground methods
    private void OnGround()
    {
        CheckCollisionWithWallsOnMove();
    }
    /// <summary>
    /// Checks posible wall colliders in front of player direction. 
    /// </summary>
    private void CheckCollisionWithWallsOnMove()
    {
        if (Physics2D.Raycast(transform.position, transform.right, distanceFront, groundLayer))
        {
            idle = true;
        }
    }
    #endregion
    #region Input
    public void OnLook(InputAction.CallbackContext context){
        mouseSightPosition=mainCam.ScreenToWorldPoint(context.ReadValue<Vector2>());
        mouseSight.position=mouseSightPosition;
        frontArmTarget.position = mouseSight.position;
        if(secondHandGrab!=null)secondHandGrab.position = twoHandsGun.position;
        if(mouseSight.GetX()>transform.GetX()){
            transform.localScale=new Vector2(1,1);
        }else{
            transform.localScale = new Vector2(-1, 1);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed && movement)
        {
            xInput = context.ReadValue<Vector2>().x;
            if (xInput > 0) transform.eulerAngles.Set(0, 0, 0);
            else transform.eulerAngles.Set(0, 180, 0);
        }
        else
        {
            xInput = 0;
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && movement && onGround)
        {
            jump = true;
            animator.SetTrigger("jump");
            StartCoroutine(Jumping());
        }
        else jump = false;
    }
    public void OnFire(InputAction.CallbackContext context){
        if(context.performed && movement){
            if(gun!=null){
                gun.Shoot();
            }
        }
    }
    #endregion
    /// <summary>
    /// Increase player jump altitude over time, when held the jump button.
    /// </summary>
    /// <returns></returns>
    IEnumerator Jumping()
    {
        float currentTimeJumping = 0;
        while (currentTimeJumping <= timeJumping && jump)
        {
            currentTimeJumping += 0.01f;
            yield return new WaitForSecondsRealtime(0.005f);
        }
        rigid.SetVelocity(rigid.velocity.x,0);
        jump = false; 
    }
}
