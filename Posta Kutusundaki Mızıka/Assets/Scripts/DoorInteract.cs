using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sercan.Scripts.Controllers;


public class DoorInteract : MonoBehaviour
{
    public Animator animator;
    private Inventory inven;

    // Start is called before the first frame update
    void Start()
    {
        inven = GetComponent<Inventory>();
        print(inven);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButton(0)) // wants mouse left click
        {
            Debug.Log("Click");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))//Checking ray
            {
                Debug.Log("Ray");
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Door")) // works on layer Door
                {

                    if (hit.collider.gameObject.name == "PivotDoor001")
                    {

                        if (inven.IsThereObject(InventoryObject.key1))
                        {
                            animator.SetTrigger("Open");
                        }
                        else
                        {
                            animator.SetTrigger("Try");


                        }
                    }
                    else
                    {
                        if (inven.IsThereObject(InventoryObject.key2))
                        {
                            animator.SetTrigger("Open");
                        }
                        else
                        {
                            animator.SetTrigger("Try");


                        }
                    }
                }
            }
        }
    }

  }
