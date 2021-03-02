using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    public bool isGrounded;
    public Transform groundCheck;
    
    
    public Transform roofCheck;
    public bool isOnCheckPoint;
    public float checkDist = 0.2f;
    public LayerMask groundMask;
    public LayerMask checkPointdCheck;

    public float smoothRotation = 0.1f;
    private float smoothVelocity;

    public float smoothJump = 1f;
    private float smoothGravity;

    public float smoothRush = 0.3f;
    private Vector3 smoothRushStop;

    public float speed = 10f;
    public float gravityPower = 9f;
    public float jump = 10f;
    public float rush = 100f;

    private bool rushing = false;
    private bool canRush = false;
    private bool doubleJump = false;
    private bool jumping = false;
    private bool onWall = false;

    
    public CharacterController controller;
    public Transform cam;
    private Vector3 gravityVelocity;
    private Vector3 rushVelocity;
    private Vector3 moveDir = new Vector3(0, 0, 0);

    private Vector3 direction;


    public bool doubleJumpAvailable = false;
    public bool wallJumpAvailable = false;
    public bool rushAvailable = false;

    void Start()
    {


    }
    void OnGUI()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "This")
        {

            Debug.Log("Player Hit the Wall");
        }
    }

    void Update()
    {
        Moving();
        OnCheckPoint();
        Jump();
        Gravity();
        if(rushAvailable)
            Rush();
        if(wallJumpAvailable)
            OnWall();
    }

    void Moving()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(x, 0, z).normalized;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothRotation);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }
       

    }
    void OnCheckPoint()
    {
        isOnCheckPoint= Physics.CheckSphere(groundCheck.position, checkDist, checkPointdCheck);

    }
    void Jump()
    {
        if ((Input.GetButtonDown("Jump")) && (doubleJump)&&(onWall|| doubleJumpAvailable))
        {
            jumping = false;
            gravityVelocity.y = Mathf.Sqrt(-jump * gravityPower);
            doubleJump = false;
        }
        if ((Input.GetButtonDown("Jump")) && (isGrounded))
        {

            gravityVelocity.y = Mathf.Sqrt(jump * -2 * gravityPower);
            doubleJump = true;
        }
        if (Input.GetButtonUp("Jump") && gravityVelocity.y > 0)
        {
            jumping = true;

            //transform.position- transform.up*transform.position.y*0.9f
        }

        if (jumping && gravityVelocity.y > 0)
        {
            gravityVelocity.y = Mathf.SmoothDamp(gravityVelocity.y, gravityVelocity.y * 0.7f, ref smoothGravity, smoothJump);

        }
        controller.Move(gravityVelocity * Time.deltaTime);
    }

    void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkDist, groundMask);
        bool under = Physics.CheckSphere(roofCheck.position, checkDist, groundMask);
        if (isGrounded && gravityVelocity.y <= 0)
        {
            canRush = true;
            jumping = false;
            gravityVelocity.y = -20f;
        }
        
        if (under && gravityVelocity.y >= 0)
        {
            gravityVelocity.y = -1f;
        }
        if (onWall && gravityVelocity.y <= 0)
        {
            gravityVelocity.y = -7f;
        }
        gravityVelocity.y += gravityPower * Time.deltaTime;
        controller.Move(gravityVelocity * Time.deltaTime);
    }

    void Rush()
    {
        if (Input.GetButtonDown("Fire3")&&canRush)
        {
            doubleJump = true;
            rushing = true;
            rushVelocity = moveDir * rush;
            canRush = false;
        }
        if(rushing)
        {
            
            controller.Move(rushVelocity * Time.deltaTime);
            rushVelocity = Vector3.SmoothDamp(rushVelocity, Vector3.zero, ref smoothRushStop, smoothRush);

            if (rushVelocity.magnitude <= 0.1f)
            {
                rushing = false;
                if (gravityVelocity.y<0)
                gravityVelocity.y = -10f;
            }
                
        }
    }

    void OnWall()
    {
        if (Physics.Raycast(transform.position, moveDir, 2f, groundMask))
        {
            onWall = true;
            doubleJump = true;
        }
        else
        {
            onWall = false;
        }
    }
}
    