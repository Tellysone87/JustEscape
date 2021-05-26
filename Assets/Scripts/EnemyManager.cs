// Author: Shantel Williams
// Date: 11/26/2020
// File Name: Enemy Manager
// 
// Description: This code is assigned to the enemy object.
// The purpose is to manage the enemies health and have it flash each 
// time damage is taking. 
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{

    public int currentHealth; // Current health during game
    public int maxHealth; // max health the enemy will have

    private bool FlashActive; 
    [SerializeField] // field for input
    private float FlashLength = 0f;
    private float FlashCounter = 0f;
    private SpriteRenderer EnemySprite;



    // Start is called before the first frame update
    
    void Start()
    {
        EnemySprite = GetComponent<SpriteRenderer>(); // reference to enemy sprite renderer
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////
    // Update is called once per frame
    // I put the flash in the update function. You can make the sprite flash by only manipulating the
    // alpha of the sprite. 0 being clear and 1 being full alpha. The if statement is alternating
    // every 17/16th of a second. This gives the flash effect.
    // new Color(red, green, blue, alpha)
    ///////////////////////////////////////////////////////////////////////////////////////////////////
   
    void Update()
    {
        if (FlashActive)
        {
            if (FlashCounter > FlashLength * .99f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .82f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);
            }
            else if (FlashCounter > FlashLength * .66f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .49f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);
            }
            else if (FlashCounter > FlashLength * .33f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .16f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);
            }
            else if (FlashCounter > 0f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);
            }

            else
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);
                FlashActive = false;
            }
            FlashCounter -= Time.deltaTime;
        }
    }

    
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    /// This function is called to minus health from player and set flash to active.
    /// If enemy is out of health the gameObject will be set to flase and appear as if its gone.
    /// I make an object of enemyManager in HurtEnemy and this is where this function is passed. 
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        FlashActive = true;
        FlashCounter = FlashLength;
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            
        }
    }
}

