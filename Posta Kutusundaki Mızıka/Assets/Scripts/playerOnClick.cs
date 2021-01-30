﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class playerOnClick : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float turnSpeed = 15f;

    private Animator anim;
    private CharacterController Controller;
    private CollisionFlags collisionFlags = CollisionFlags.None;
    
    private Vector3 playerMove = Vector3.zero;
    private Vector3 targetMovePoint = Vector3.zero;
    
    private float currentSpeed;
    private float playerToPointDistence;
    private float gravity = 9.8f;
    private float height;

    private bool canMove;
    private bool finishedMovement = true;
    private Vector3 newMovePoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        Controller = GetComponent<CharacterController>();
        currentSpeed = maxSpeed;
    }


    void Update()
    {
       CalculateHeight();
       CheckIfFinishedMovement();
       
    }
    bool isGrounded()
    {
        return collisionFlags == CollisionFlags.CollidedBelow ? true : false;
    }

    void CalculateHeight()
    {
        if (isGrounded())
        {
            height = 0f;
        }
        else
        {
            height -= gravity * Time.deltaTime;
        }
    }

    void CheckIfFinishedMovement()
    {
        if (!finishedMovement)
        {
            if (!anim.IsInTransition(0) && !anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f)
            {
                finishedMovement = true;
            }
        }
        else
        {
            MovePlayer();
            playerMove.y = height * Time.deltaTime;
            collisionFlags = Controller.Move(playerMove);
        }
    }

    void MovePlayer()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                playerToPointDistence = Vector3.Distance(transform.position, hit.point);
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    if (playerToPointDistence >= 1.0f)
                    {
                        canMove = true;
                        targetMovePoint = hit.point;
                    }
                }
            }
        }

        if (canMove)
        {
            anim.SetFloat("Speed",1.0f);
            
            newMovePoint = new Vector3(targetMovePoint.x,transform.position.y,targetMovePoint.z);

            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(newMovePoint - transform.position), turnSpeed * Time.deltaTime);

            playerMove = transform.forward * turnSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, newMovePoint) <= 0.6f)
            {
                canMove = false;
            }
        }
        else
        {
            playerMove.Set(0f,0f,0f);
            anim.SetFloat("Speed",0f);
        }
    }
}
