using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragneel
{
    public class IP_Base_Airplane_Input : MonoBehaviour
    {
        #region Variables
        protected float pitch = 0f;
        protected float roll = 0f;
        protected float yaw = 0f;

        protected float throttle = 0f;
        public KeyCode brakekey = KeyCode.Space;
        protected float brake = 0f;

        public int MaxFlapIncrements = 2;
        protected int flaps = 0;
        #endregion

        #region Properties
        public float Pitch
            {
            get { return pitch; }
            }
        
        public float Roll
        {
            get { return roll; }
        }

        public float Yaw
        {
            get { return yaw; }
        }

        public float Throttle
        {
            get { return throttle; }
        }

        public int Flaps
        {
            get { return flaps; }
        }

        public float Brake
        {
            get { return brake; }
        }

        #endregion


        #region Bultin Methods
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            HandleInput();
        }
        #endregion



        #region Costom Method
        protected virtual void HandleInput()
        {
            // Input Properties
            pitch = Input.GetAxis("Vertical");
            roll = Input.GetAxis("Horizontal");
            yaw = Input.GetAxis("Yaw");
            throttle = Input.GetAxis("Throttle");

            // Debug.Log("Pitch:" + pitch + "-" + "Roll" + roll );
            
            //process Brake Inputs
            brake = Input.GetKey(brakekey)? 1f:0f ; 
            
            // Process flaps Inputs
            if(Input.GetKeyDown(KeyCode.F))
            {
                flaps += 1;
            }
            if(Input.GetKeyDown(KeyCode.G))
            {
                flaps -= 1;
            }

            flaps = Mathf.Clamp(flaps, 0, MaxFlapIncrements);
        }
        #endregion
    }
}