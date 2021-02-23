﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleController : MonoBehaviour
{
    public bool isGrounded;
    public Transform groundCheck;
    public Transform roofCheck;
    public float checkDist = 0.2f;
    public LayerMask groundMask;
    public LayerMask cubeParent;

    public float smoothRotation = 0.1f;
    private float smoothVelocity;
    public float smoothJump = 1f;
    private float smoothGravity;

    public  float speed = 10f;
    public float gravityPower = 9f;
    public float jump = 10;
    private bool doubleJump = false;
    private bool jumping = false;

    public Vector3 gravityVelocity ;
    public CharacterController controller;
    public  Transform cam;

    private Vector3 direction;
    
    

    

    void Start()
    {

        
    }
    void OnGUI()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    void Update()
    {
        Moving();
        Jump();
        Gravity();    }

    void Moving()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, checkDist, groundMask);
        bool under = Physics.CheckSphere(roofCheck.position, checkDist, groundMask);
        if (((isGrounded)&&(gravityVelocity.y<=0))||(under))
        {
            jumping = false;
            gravityVelocity.y = -10f;      
        }

       
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        
        

        direction = new Vector3(x, 0, z).normalized;
        Vector3 moveDir=new Vector3(0,0,0);
        if (direction.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg+cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothRotation);
            transform.rotation = Quaternion.Euler(0, angle, 0);

                moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
              controller.Move(moveDir * speed * Time.deltaTime);
        }


    }
    void Jump()
    { if ((Input.GetButtonDown("Jump")) && (doubleJump))
        {
            jumping = false;
            gravityVelocity.y = Mathf.Sqrt(-jump  * gravityPower);
            doubleJump = false;
        }
        if ((Input.GetButtonDown("Jump")) && (isGrounded))
        {
            
            gravityVelocity.y = Mathf.Sqrt(jump* -2 * gravityPower);
            doubleJump = true;
        }
        if (Input.GetButtonUp("Jump")&& gravityVelocity.y>0)
        {
            jumping = true;
           
            //transform.position- transform.up*transform.position.y*0.9f
        }

        if (jumping && gravityVelocity.y > 0)
        {
 gravityVelocity.y = Mathf.SmoothDamp(gravityVelocity.y, gravityVelocity.y*0.7f, ref smoothGravity, smoothJump);

        }
        controller.Move(gravityVelocity * Time.deltaTime);
    }
    void Gravity()
    {
        gravityVelocity.y += gravityPower * Time.deltaTime;
        controller.Move(gravityVelocity * Time.deltaTime);
    }
}
    