using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class playerMovement : MonoBehaviour
{
    public Flowchart Flowchart;
    public float moveSpeed;

    public Rigidbody2D rb;
    public Animator animator;
    public vectorValue startingPos;

    Vector2 movement;

    private void Start()
    {
        transform.position = startingPos.initialValue;
        
    }

    void FixedUpdate()
    {
        
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastVertical", Input.GetAxisRaw("Vertical"));
        }

        if (Flowchart.isActiveAndEnabled)
        {
            return;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
    
}
