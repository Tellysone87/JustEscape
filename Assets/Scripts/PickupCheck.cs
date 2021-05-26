// Author: Shantel Williams
// Date: 12/4/2020
// File Name: FuelPickUp
// 
// Description: This code is assigned to the spaceShip object.
// This code checks to see if an inventory slot contains one of the items needed
// and then the item can removed from the needed pick up. 
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupCheck : MonoBehaviour
{

    private Inventory inventory; // Created object of Inventory class
    public GameObject imageToRemove; // image to remove over ship
    public float SecondToLaunchEnd = 2f;

    // Start is called before the first frame update
    void Start()
    {
       
       inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();// finds player 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //////////////////////////////////////////////////////////////////////////////////////////////////
    ///              Checks if both objects in arrays are collected and runs end scene
    //////////////////////////////////////////////////////////////////////////////////////////////////
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (inventory.isFull[0] == true && inventory.isFull[1] == true)
            {
                Destroy(imageToRemove);
                EndOfGame();
                
            }                
            
        }
    }

    public void EndOfGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads next scene
    }
} 
