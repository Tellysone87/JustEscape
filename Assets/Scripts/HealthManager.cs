// Author: Shantel Williams
// Date: 11/26/2020
// File Name: Player Manager
// 
// Description: This code is assigned to the player object.
// The purpose is to manage the players health and have it flash each 
// time damage is taking. 
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;

    private bool FlashActive;
    [SerializeField] // field for input
    private float FlashLength = 0f;
    private float FlashCounter = 0f;
    private SpriteRenderer PlayerSprite;



    // Start is called before the first frame update
    void Start()
    {
        PlayerSprite = GetComponent<SpriteRenderer>();// reference to player sprite renderer.
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
            if (FlashCounter > FlashLength *.99f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .82f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 1f);
            }
            else if (FlashCounter > FlashLength * .66f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .49f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 1f);
            }
            else if (FlashCounter > FlashLength * .33f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0f);
            }
            else if (FlashCounter > FlashLength * .16f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 1f);
            }
            else if (FlashCounter > 0f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0f);
            }

            else
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 1f);
                FlashActive = false;
            }
            FlashCounter -= Time.deltaTime;
        }
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////
    /// This function is called to minus health from player and set flash to active.
    /// If player is out of health the gameObject will be set to false and appear as if its gone.
    /// The scene will then be reset to the start.
    /// I make an object of HealthManager in HurtPlayer and this is where this function is passed. 
    /////////////////////////////////////////////////////////////////////////////////////////////////////
    public void HurtPlayer( int damageToGive)
    {
        currentHealth -= damageToGive;
        FlashActive = true;
        FlashCounter = FlashLength;
        if(currentHealth <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
