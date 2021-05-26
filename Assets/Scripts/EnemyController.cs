// Author: Shantel Williams
// Date: 11/26/2020
// File Name: Enemy Controller
// 
// Description: This code is assigned to the enemy object. The variables are for the Animation,Target or Player to chase,
// Speed fo movement, max and min range to chase player and home position to return to.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim; // Animator
    private Transform target; // target or player
    [SerializeField] // field for input
    private float speed; // speed of movement
    [SerializeField] // field again
    private float MaxRange; // max range
    [SerializeField] //field a third time
    private float MinRange; // min range
    public Transform Homepos; // home positon for alien/enemy
    NavMeshAgent agent; // Navigation Agent
    private GameObject sword;
    
    


    // Start is called before the first frame update
    void Start()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////// gets NavMeshAgent component.The other lines where to get the 2d pathfinder to behave right///
        //////// Idk what exactly it does.                                                                 ///
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false; 
        agent.updateUpAxis = false;

                                            /////////////////////////////
        myAnim = GetComponent<Animator>(); // gets animation component
                                           /////////////////////////////
                                           
                                                                ///////////////////////////////
        target = FindObjectOfType<PlayerMovement>().transform; // finds player object location
                                                               ///////////////////////////////
    }
    ///////////////////////////////////
    // Update is called once per frame
    //////////////////////////////////
    void Update()
    {
        if(Vector3.Distance(target.position, transform.position) <= (MaxRange + transform.position.z) && Vector3.Distance(target.position, transform.position) >= (MinRange + transform.position.z))
        {
            /////////////////////////////////////
            FollowPlayer(); ///Chases player////
            ////////////////////////////////////
        }

        else if (Vector3.Distance(target.position, transform.position) >= MaxRange)
        {
            ////////////////////////////////
            GoHome();   /// Returns home///
            //////////////////////////////
        }


    }

    public void FollowPlayer()
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        //                       Sets movement to true and controls animations                           //
        //////////////////////////////////////////////////////////////////////////////////////////////////
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("movex", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        

        //////////////////////////////////////////////////////////////////////////////////////////////////
        //                         AI pathfinding line to player                                        //
        /////////////////////////////////////////////////////////////////////////////////////////////////
        agent.destination = target.position;
    }

    public void GoHome()
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
       //                                 Controls Animations                                             //
       /////////////////////////////////////////////////////////////////////////////////////////////////////
        myAnim.SetFloat("movex", (Homepos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (Homepos.position.y - transform.position.y));
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //                              AI pathfinding line to Homeposition                               //
        ///////////////////////////////////////////////////////////////////////////////////////////////////
        agent.destination = Homepos.position;

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        //                    Condition to stop animation once enemy is at home position                     //
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Vector3.Distance(transform.position, Homepos.position) <= 1.643333)
        {
            myAnim.SetBool("isMoving", false);
         
        }
        
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////
    // This function provides kick back to the enemy after sword collision - not working
    /////////////////////////////////////////////////////////////////////////////////////////
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.GetComponent<Collider2D>().tag == "Sword")
    //    {
    //        Debug.Log("sword collision");
    //        Vector2 difference = transform.position - other.transform.position;
    //        transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
    //    }
    //}


}
