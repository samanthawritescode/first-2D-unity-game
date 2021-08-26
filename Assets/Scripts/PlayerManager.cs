using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public Inventory inventory;
    private InventoryItem itemToPickup;

    private void Start() {
        inventory = new Inventory();
    }

    private void Update() {
        // input.mouseposition and input.getMouseButtonDown
        if(Input.GetKeyDown(KeyCode.E) && itemToPickup != null) { 
            PickupItem(itemToPickup);
        }
    }

    public void PrepItemForPickup(InventoryItem item) { 
        itemToPickup = item;
    }

    public void PurgeItemForPickup(InventoryItem item) { 
        itemToPickup = null;
    }


    // private 

    private void PickupItem(InventoryItem item) { 
        // temp for debugging
        Debug.Log("Added 1 " + item.type + " item to inventory!");
        inventory.AddItem(item, 1);
        item.OnPickup();
        itemToPickup = null;
    }
}
