// Author: Shantel Williams
// Date: 11/26/2020
// File Name: Player Movement
// 
// Description: This code is assigned to the player object.
// This code takes input and moves the player. It also handles 
// player animations and attacks.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;   // Controls move speed
    public Rigidbody2D rb;      // players rigidbody
    private Vector2 MoveDirection; // direction
    public Animator anim; // animator
    private Vector2 lastMoveDirection; // last move direction
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        animate();
    }

    // This function is called every fixed framerate frame
    void FixedUpdate()
    {
        Move();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////
    // This function get the input for the user via the keyboard
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");  // gets left or right, a and d
        float movey = Input.GetAxisRaw("Vertical"); // gets up or down, w and s

        // Checks last movement from player
        if((moveX == 0 && movey == 0) && MoveDirection.x != 0 || MoveDirection.y != 0)
        {
            lastMoveDirection = MoveDirection;
        }


        MoveDirection = new Vector2(moveX, movey).normalized;
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////
    /// Moving player using Rigibody.velocity. Velocity is rate of change in position.
    //////////////////////////////////////////////////////////////////////////////////////////////////
    void Move()
    {
        rb.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

    
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// This function is to display the animations of my player. It uses x and y values
    /// to set transitions using the Blend Tree. 
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    void animate()
    {
        anim.SetFloat("AnimMoveX", MoveDirection.x);
        anim.SetFloat("AnimMoveY", MoveDirection.y);
        anim.SetFloat("AnimMoveMagnitude", MoveDirection.magnitude);
        anim.SetFloat("AnimeLastMoveX", lastMoveDirection.x);
        anim.SetFloat("AnimeLastMoveY", lastMoveDirection.y);

        if (isAttacking)
        {
            rb.velocity = Vector2.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                anim.SetBool("IsAttacking", false);
                isAttacking = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackCounter = attackTime;
            anim.SetBool("IsAttacking", true);
            isAttacking = true;
        }

    }
}
