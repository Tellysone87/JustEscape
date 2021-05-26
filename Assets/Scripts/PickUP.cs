// Author: Shantel Williams
// Date: 12/4/2020
// File Name: PickUp
// 
// Description: This code is assigned to the Keycard object.
// This code checks to see if an inventory slot is empty and then the item can be added to 
// the inventory slot. 
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PickUP : MonoBehaviour
{
    private Inventory inventory; // Created object of Inventory class
    public GameObject itemButton; // pickup button
    public UnityEngine.Experimental.Rendering.Universal.Light2D GameLights; // light

    // Start is called before the first frame update
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();// finds player
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.CompareTag("Player")) {
           for(int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)// chacks if inventory is full
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    GameLights.enabled = !GameLights.enabled;
                    break;
                }
            }
        }
    }
}
