using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {
    private InventoryItem item;

    private void OnTriggerEnter2D(Collider2D collision) {
       PlayerManager manager = collision.GetComponent<PlayerManager>();
       if (manager) { 
            item = gameObject.GetComponent<InventoryItem>();
            if (item == null) { 
                Debug.LogWarning("Pickup class did not find expected InventoryItem");
                return;
            }

            manager.PrepItemForPickup(item);
       }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        PlayerManager manager = collision.GetComponent<PlayerManager>();
        if (manager) { 
            item = gameObject.GetComponent<InventoryItem>();
            if (item == null) { 
                Debug.LogWarning("Pickup class did not find expected InventoryItem");
                return;
            }

            manager.PurgeItemForPickup(item);
       }
    }
}
