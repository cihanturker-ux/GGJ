using System;
using System.Collections;
using Sercan.Scripts.Movement;
using UnityEditor.Animations;
using UnityEngine;
using Sercan.Scripts.Controllers;
using Sercan.Scripts.InteractableObjects;
using Sercan.Scripts.Managers;

namespace Sercan.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [Range(0, 10)] [SerializeField] private float senstivity;
        [SerializeField] private Transform homeSpawnPos;
        
        private Rigidbody rb;
        private AnimationController anim;
        private Mover mover;
        private InputController input;
        private AudioSource audio;
        private UIManager uı;
        private SoundManager soundManager;

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
            uı = FindObjectOfType<UIManager>();
            soundManager = FindObjectOfType<SoundManager>();
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "FamilyImage")
            {
                soundManager.ClipPlay(0);   
                return;
                
            }
            uı.DialoguePanel(true,other.GetComponent<Dialogues>().text);
            if (other.tag == "Door")
            {
                soundManager.ClipPlay(0);
            }
            
            
            
        }

        private void OnTriggerExit(Collider other)
        {
            uı.DialoguePanel(false,other.GetComponent<Dialogues>().text);
            if (other.tag == "Door")
            {
                StartCoroutine(DoorFade());
                transform.position = homeSpawnPos.position;
            }

        }

        IEnumerator DoorFade()
        {
            uı.fadePanel.SetActive(true);
            yield return new WaitForSeconds(1);
            uı.fadePanel.SetActive(false);
        }
    }
}