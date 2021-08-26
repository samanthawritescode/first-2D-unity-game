using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {
    public ItemType type;
    public enum ItemType { 
        Rock,
        Diamond
    }

    public void OnPickup() { 
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
       PlayerManager manager = collision.GetComponent<PlayerManager>();
       if (manager) { 
            InventoryItem item = gameObject.GetComponent<InventoryItem>();
            manager.PrepItemForPickup(item);
       }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        PlayerManager manager = collision.GetComponent<PlayerManager>();
        if (manager) { 
            InventoryItem item = gameObject.GetComponent<InventoryItem>();
            manager.PurgeItemForPickup(item);
       }
    }
}
