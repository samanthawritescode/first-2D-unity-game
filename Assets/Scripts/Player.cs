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

    void Update() { }

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

    
}
