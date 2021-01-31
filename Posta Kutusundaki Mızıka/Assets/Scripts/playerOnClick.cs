using System;
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

   // private Animator anim;
   // private CharacterController Controller;
    private CollisionFlags collisionFlags = CollisionFlags.None;
    
    private Vector3 playerMove = Vector3.zero;
    private Vector3 targetMovePoint = Vector3.zero;
    
    
    private float playerToPointDistence;
    
  

    private bool canMove;
    private bool finishedMovement = true;
    private Vector3 newMovePoint;
    private Vector3 walkingPoint;
    private bool onDistance = false;
    private float journeyLength;
    private void Awake()
    {
      //  anim = GetComponent<Animator>();
    
        
    }


    void FixedUpdate()
    {
     
      
        MovePlayer();
        isOnDistance();
    }
   

   
    void isOnDistance()
    {

        if(journeyLength > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, walkingPoint, Time.fixedDeltaTime * 1f);
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
                        Debug.Log("Etap4");
                        canMove = true;
                        targetMovePoint = hit.point;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                   
                    
                    walkingPoint =new Vector3(hit.point.x,transform.position.y,hit.point.z);
                    journeyLength = Vector3.Distance(transform.position, walkingPoint);

                   
                   

                }
            }
        }
        if (canMove)
        {
            // anim.SetFloat("Speed",1.0f);
          //  Debug.Log("Etap1");
            newMovePoint = new Vector3(targetMovePoint.x,transform.position.y,targetMovePoint.z);
            
            
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(newMovePoint - transform.position), turnSpeed * Time.deltaTime);

            playerMove = transform.forward * turnSpeed * Time.deltaTime;
            if (Vector3.Distance(transform.position, newMovePoint) <= 0.6f)
            {
               // Debug.Log("Etap2");
                canMove = false;
            }
        }
        
    }
   
}
