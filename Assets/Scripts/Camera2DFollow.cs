// Author: Shantel Williams
// Date: 11/26/2020
// File Name: Camera2DFollow
// 
// Description: This file is to have the camera follow the player and provide restriction on the 
// game level. This code is from the plateform 2d tutorial and it was adjusted for my game style 
// and likings. 
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {
	
	public Transform target;
	public float damping = 1;
	public float lookAheadFactor = 3;
	public float lookAheadReturnSpeed = 0.5f;
	public float lookAheadMoveThreshold = 0.1f;
	public float yMinPosRestriction = -14.5f;
	public float yMaxPosRestriction = 2.27f;
	private float xMinPosRestriction = -14.83f;
	private float xMaxPosRestriction = 15.871f;

	float offsetZ;
	Vector3 lastTargetPosition;
	Vector3 currentVelocity;
	Vector3 lookAheadPos;

	float nextTimeToSearch = 0;
	
	// Use this for initialization
	/////////////////////////////////////////////////////////////////////////////////////////////////
    //// On Start the camera is instructed to find the player and other words to focus on the player.
    /////////////////////////////////////////////////////////////////////////////////////////////////
	void Start () {
		lastTargetPosition = target.position;
		offsetZ = (transform.position - target.position).z;
		transform.parent = null;
	}
	
	// Update is called once per frame
	void Update () {

		if (target == null) {
			FindPlayer ();
			return;
		}

		// only update lookahead pos if accelerating or changed direction
		float xMoveDelta = (target.position - lastTargetPosition).x;

	    bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

		if (updateLookAheadTarget) {
			lookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
		} else {
			lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);	
		}
		
		Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

		///////////////////////////////////////////////////////////////////////////
        /// Line to keep camera inside of my map. Clamp(value, min, max)
        /// //////////////////////////////////////////////////////////////////////
		newPos = new Vector3 (Mathf.Clamp(newPos.x, xMinPosRestriction, xMaxPosRestriction), Mathf.Clamp (newPos.y, yMinPosRestriction, yMaxPosRestriction), newPos.z);

		transform.position = newPos;
		
		lastTargetPosition = target.position;		
	}

	//////////////////////////////////////////////////////////////////////////////////////////////////
    /// Function to find player
    ///////////////////////////////////////////////////////////////////////////////////////////////// 
	void FindPlayer () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");
			if (searchResult != null)
				target = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
}
