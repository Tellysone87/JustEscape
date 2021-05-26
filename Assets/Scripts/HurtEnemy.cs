// Author: Shantel Williams
// Date: 11/26/2020
// File Name: Hurt Enemy
// 
// Description: This code is assigned to the sword object. when the sword makes collision
// with the enemy sprite, the enemy will lose health. I made an object of EnemyManager
// and that object calls the HurtPlayer function.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtEnemy : MonoBehaviour
{
    
    public bool istouching; // Check for Collision
    public EnemyManager healthManEnemy; // object of Enemy Manager
    [SerializeField] //field a third time
    private int damageToGet = 10; // Damage dealt per collision

    // Start is called before the first frame update
    void Start()
    {
        healthManEnemy = FindObjectOfType<EnemyManager>(); // Setting object to enemy sprite
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "enemy")
        {
            other.gameObject.GetComponent<EnemyManager>().HurtPlayer(damageToGet);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "enemy")
        {
            istouching = true;
        }

    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "enemy")
        {
            istouching = false;

        }
    }
}
