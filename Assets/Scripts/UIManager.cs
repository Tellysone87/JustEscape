// Author: Shantel Williams
// Date: 11/26/2020
// File Name: UI Manager
// 
// Description: This code is assigned to the Enemy Canvas object. This code is
// to control the Enemies health bar and display the current health. This also borrows
// members from the EnemyManager Class.
//
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    private EnemyManager healthMan2; // object to get member value
    public Slider EnemyhealthBar; // slider for Enemies health
    public Text EnemyHpText; // display text on slider

    // Start is called before the first frame update
    void Start()
    {
        
        healthMan2 = FindObjectOfType<EnemyManager>(); // finds Enemy object 

        EnemyhealthBar = GameObject.Find("EnemyHealthBar").GetComponent<Slider>();// Enemy health bar
    }

    // Update is called once per frame
    void Update()
    {

        /////////////////////////////////////////////////////////////////
        ///                    Enemy Health Bar                      ///
        ///////////////////////////////////////////////////////////////

        EnemyhealthBar.maxValue = healthMan2.maxHealth;
        EnemyhealthBar.value = healthMan2.currentHealth;
      
        if (EnemyhealthBar.value == 0)
        {
            EnemyhealthBar.gameObject.SetActive(false);
        }

    }
}
