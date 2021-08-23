using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed;
    public Rigidbody2D rb;
    Vector2 movement;
    public SpriteRenderer spriteRenderer;
    public Sprite backSprite;
    public Sprite forwardSprite;
    public Sprite sideSprite;

    public Inventory inventory;

    private void Start() {
        inventory = new Inventory();
    }

    void Update() {

// input.mouseposition and input.getMouseButtonDown

        if(Input.GetKeyDown(KeyCode.E) && itemToPickup != null) { 
            Debug.Log("Added 1 " + itemToPickup.type + " item to inventory!");
            inventory.AddItem(itemToPickup, 1);
            itemToPickup.OnPickup();
        }
   }

   private void FixedUpdate() {
        SetMovementFromInput();
        rb.velocity = movement * moveSpeed;

        if (movement.y == 1) {
            spriteRenderer.sprite = backSprite;
        } else if (movement.y == -1) { 
            spriteRenderer.sprite = forwardSprite;
        } else if (movement.x == 1) { 
            spriteRenderer.sprite = sideSprite;
            spriteRenderer.flipX = true;
        } else if (movement.x == -1) { 
            spriteRenderer.sprite = sideSprite;
            spriteRenderer.flipX = false;
        }
   }

    void SetMovementFromInput () { 
        float mx = Input.GetAxisRaw("Horizontal"); 
        float my = Input.GetAxisRaw("Vertical");
        movement = new Vector2(mx, my).normalized;
    }


    // ITEM PICKUP

    private InventoryItem itemToPickup = null;
    private void OnTriggerEnter2D(Collider2D other) {

        InventoryItem item = other.GetComponent<InventoryItem>();
        if (item != null) { 
            itemToPickup = item;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        InventoryItem item = other.GetComponent<InventoryItem>();
        if (item != null) { 
            itemToPickup = null;
        }
    }

    
}
