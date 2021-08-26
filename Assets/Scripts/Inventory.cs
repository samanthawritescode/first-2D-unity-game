using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {
    private Dictionary<InventoryItem.ItemType, int> itemStore;

    public Inventory() {
        itemStore = new Dictionary<InventoryItem.ItemType, int>();
    }

    public void AddItem(InventoryItem item, int count = 1) { 
        if (!itemStore.TryGetValue(item.type, out int current)) { 
            itemStore.Add(item.type, count);
        } else { 
            itemStore[item.type] += count;
        }

        // temp for debugging
        PrintInventoryStatus();
    }

    public void PrintInventoryStatus() { 
        foreach (KeyValuePair<InventoryItem.ItemType, int> slot in itemStore) {  
            Debug.Log("INVENTORY -- item: " + slot.Key + ", count: " + slot.Value);  
        } 
    }
}
