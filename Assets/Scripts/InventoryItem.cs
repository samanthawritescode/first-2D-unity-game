using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour {
    public ItemType type;
    public enum ItemType { 
        Rock, 
    }

    public void OnPickup() { 
        Destroy(gameObject);
    }
}
