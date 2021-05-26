// Author: Shantel Williams
// Date: 11/26/2020
// File Name: Hurt Player
// 
// Description: This code is assigned to the enemy object. when the enemy makes collision
// with the player sprite, the player will lose health. There is also a 2 second cool down between 
// damage. I made an object of HealthManager and that object calls the HurtPlayer function.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    public float waitToHurt = 3f; // time to wait
    public bool istouching; // checks for collision
    private HealthManager healthMan; // object of Health Manager
    [SerializeField] //field a third time
    private int damageToGet = 10; // damage dealt

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>(); // finds player object
    }

    // Update is called once per frame
    void Update()
    {
        //////////////////////////////////////////////////
        //// Cool time for damage by enemy
        /////////////////////////////////////////////////
        if (istouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthMan.HurtPlayer(damageToGet);
                waitToHurt = 3f;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGet);
            
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            istouching = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            istouching = false;
            waitToHurt = 3f;

        }
    }
}
