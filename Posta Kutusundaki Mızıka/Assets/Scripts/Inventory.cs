using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
   public List<InventoryObject> inventoryObjects;

    private void Start()
    {
        
    }
    public void Add(InventoryObject inventoryObject)
    {
        inventoryObjects.Add(inventoryObject);
    }

    public bool IsThereObject(InventoryObject inventoryObject)
    {
        return inventoryObjects.Contains(inventoryObject);
    }
}

public enum InventoryObject
{
    bos,   
    key1,
    key2

}