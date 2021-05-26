// Author: Shantel Williams
// Date: 11/26/2020
// File Name: Flashing Lights
// 
// Description: This code is assigned to Lights. I made this code to make my light in my environment
// flash. To acheive this I am using the universal pipeline renderer. 
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class FlashingLights : MonoBehaviour
{
    //////////////////////////////////////
    /// These are my light objects
    //////////////////////////////////////
    public UnityEngine.Experimental.Rendering.Universal.Light2D GameLights;
    public UnityEngine.Experimental.Rendering.Universal.Light2D GameLights2;
    public UnityEngine.Experimental.Rendering.Universal.Light2D GameLights3;
    public UnityEngine.Experimental.Rendering.Universal.Light2D GameLights4;
    public UnityEngine.Experimental.Rendering.Universal.Light2D GameLights5;
    
    public float MinTime;
    public float MaxTime;
    public float Timer;


    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        flickersLight();
    }

    ///////////////////////////////////////////////////////////////////////////////////////
    /// This function makes my lights flicker by enabled and disabling at random times. 
    //////////////////////////////////////////////////////////////////////////////////////
    void flickersLight()
    {

        if(Timer > 0)
        {
            GameLights.enabled = !GameLights.enabled;
            GameLights2.enabled = !GameLights2.enabled;
            GameLights3.enabled = !GameLights3.enabled;
            GameLights4.enabled = !GameLights4.enabled;
            GameLights5.enabled = !GameLights5.enabled;
            Timer = Random.Range(MinTime, MaxTime);
        }
    }
}
