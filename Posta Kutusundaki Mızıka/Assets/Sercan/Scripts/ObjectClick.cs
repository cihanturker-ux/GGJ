using System;
using UnityEngine;

namespace Sercan.Scripts
{
    public class ObjectClick : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private GameObject changedObject;
        [SerializeField] private Transform spawnPosition;

        private GameObject spawnObject;
        private UIManager uıManager;
        private Ray ray;
        private RaycastHit hit;
        private bool isMouseClick;
        private Vector3 offset;
        private Transform cam;
        private void Start()
        {
            uıManager = FindObjectOfType<UIManager>();
            cam = Camera.main.transform;
            offset = transform.position - cam.transform.position;
        }

        private void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
                isMouseClick = true;
            }
            
            CameraFollow();
            
        }

        private void FixedUpdate()
        {
            if (isMouseClick)
            {
                ChangeObject();
                isMouseClick = false;
            }
        }

        private void ChangeObject()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                changedObject = hit.transform.gameObject;
                uıManager.InteractableObjectCanvas(true);
                spawnObject = Instantiate(changedObject, spawnPosition);
            }
            else
            {
                changedObject = null;
                uıManager.InteractableObjectCanvas(false);
                
                if(spawnObject!=null)
                    Destroy(spawnObject);
                
                Debug.Log(spawnObject);
            }
        }

        void CameraFollow()
        {
            transform.position = cam.transform.position + offset;
        }
        
        
    }
}