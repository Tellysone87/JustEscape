// Author: Shantel Williams
// Date: 11/26/2020
// File Name: Player UI
// 
// Description: This code is assigned to the Screen Canvas object. This code is
// to control the players health bar and display the current health. This also borrows
// members from the HealthManager Class.
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private HealthManager healthMan; // object to get member value
    public Slider healthBar; // slider for players health
    public Text HpText; // display text on slider
    
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();// finding player object
    }

    // Update is called once per frame
    void Update()
    {
        /////////////////////////////////////////////////////////////////
        ///                    Player Health Bar                     ///
        ///////////////////////////////////////////////////////////////
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;
        HpText.text = " Player HP: " + healthMan.currentHealth + "/" + healthMan.maxHealth;

    }
}
