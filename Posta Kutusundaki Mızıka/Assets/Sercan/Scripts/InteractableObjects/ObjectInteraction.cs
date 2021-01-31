using System;
using Sercan.Scripts.InteractableObjects;
using Sercan.Scripts.Managers;
using UnityEngine;

namespace Sercan.Scripts
{
    public class ObjectInteraction : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private GameObject changedObject;
        [SerializeField] private Transform spawnPosition;

        private GameObject spawnObject;
        private InteractableObjUI uıManager;
        private PlayerController playerController;
        private UIManager uı;
        private GameManager gameManager;
        private Ray ray;
        private RaycastHit hit;
        private bool isMouseClick;
        private Vector3 offset;
        private Transform cam;
        private void Start()
        {
            uıManager = FindObjectOfType<InteractableObjUI>();
            uı = FindObjectOfType<UIManager>();
            playerController = FindObjectOfType<PlayerController>();
            gameManager = FindObjectOfType<GameManager>();
            cam = Camera.main.transform;
            offset = transform.position - cam.transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                isMouseClick = true;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                PanelDeactiveted();
            }

            if (Input.GetMouseButton(1))
            {
                ObjectRotater();
            }
        }

        private void FixedUpdate()
        {
            ChangeObject();
            if (isMouseClick)
            {
                isMouseClick = false;
            }
        }

        private void ChangeObject()
        {
            ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0));

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && !uıManager.InteractObjCanvas)
            {
               
                uı.CursorChanger(true);
                if (!isMouseClick) return;
                
                playerController.enabled = false;
                changedObject = hit.transform.gameObject;
                
                uıManager.InteractableObjectCanvas(true);
                uıManager.ObjectText(hit.transform.gameObject.GetComponent<ObjectStory>().story);
                
                spawnObject = Instantiate(changedObject, spawnPosition);
                spawnObject.transform.localScale *= 5000;
                spawnObject.transform.rotation = Quaternion.Euler(Vector3.left * 90);
                Cursor.lockState = CursorLockMode.Confined;
                
            }
            else
            {
                uı.CursorChanger(false);
            }
        }

        void PanelDeactiveted()
        {
            if (spawnObject != null)
            {
                Destroy(spawnObject);
                Cursor.lockState = CursorLockMode.Locked;
                changedObject = null;
                uıManager.InteractableObjectCanvas(false);
                playerController.enabled = true;
                
                gameManager.FinalPanel();
            }
        }

        void ObjectRotater()
        {
            if (uıManager.InteractObjCanvas)
            {
                float x = Input.GetAxis("Mouse X");

                Vector3 rotation = spawnObject.transform.rotation.eulerAngles;
                rotation.y -= x*3;
                spawnObject.transform.rotation = Quaternion.Euler(rotation);
            }
        }
        
        
    }
}