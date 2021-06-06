using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dragneel
{
    public class IP_Xbox_Airplane_Input : IP_Base_Airplane_Input
    {
        protected override void HandleInput()
        {
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("X_RH_Stick");
            throttle = Input.GetAxis("X_RV_Stick");

            // Debug.Log("Pitch:" + pitch + "-" + "Roll" + roll );

            //process Brake Inputs
            brake = Input.GetAxis("Fire1");


            // Process flaps Inputs
            if (Input.GetButtonDown("X_R_Bumper"))
            {
                flaps += 1;
            }

            if (Input.GetButtonDown("X_L_Bumper"))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, MaxFlapIncrements);
        }
    }
}