using System;
using Sercan.Scripts.Movement;
using UnityEditor.Animations;
using UnityEngine;
using Sercan.Scripts.Controllers;

namespace Sercan.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [Range(0, 10)] [SerializeField] private float senstivity;
        
        private Rigidbody rb;
        private AnimationController anim;
        private Mover mover;
        private InputController input;
        private AudioSource audio;

        private float horizontalMove;
        private float verticalMove;
        void Awake()
        {
            CacheComponents();
            Cursor.lockState = CursorLockMode.Locked;
        }

        #region CacheComponents

        void CacheComponents()
        {
            rb = GetComponent<Rigidbody>();
            anim = new AnimationController(GetComponentInChildren<Animator>());
            mover = new Mover(rb,transform);
            input = new InputController();
            audio = GetComponent<AudioSource>();
        }

        #endregion

        private void Update()
        {
            verticalMove = input.Vertical;
            horizontalMove = input.Horizontal;
            
        }

        private void FixedUpdate()
        {    
            mover.Move(verticalMove,horizontalMove,moveSpeed);
        }

        private void LateUpdate()
        {
            Rotater();
            anim.IdleToWalk(Mathf.Abs(verticalMove) + Mathf.Abs(horizontalMove));
            
        }

        void Rotater()
        {
            float rotateAxis = Input.GetAxis("Mouse X");
            
            Vector3 rotation = transform.rotation.eulerAngles;
            rotation.y += rotateAxis*senstivity;
            transform.rotation = Quaternion.Euler(rotation);
        }

        public void PlayWalkSound()
        {
            audio.Play();
        }
        
        
    }
}