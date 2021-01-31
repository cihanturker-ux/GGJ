using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    List<InventoryObject> inventoryObjects;

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

}