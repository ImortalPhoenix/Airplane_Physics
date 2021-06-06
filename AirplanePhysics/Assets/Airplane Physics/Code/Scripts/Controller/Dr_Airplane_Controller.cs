using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragneel
{
    public class Dr_Airplane_Controller : Dr_BaseRigidbody_Controller
    {
        #region Variables

        [Header ("Base Airplane Properties")]
        public IP_Base_Airplane_Input input;
        public Transform centerOfGravity;
        
        [Tooltip("Weight is in LBS")] 
        public float airplaneWeight = 800f;

        #endregion


        #region Constants

        const float poundsToKilos = 0.453592f;

        #endregion

        #region Builtin Method

        public override void Start()
        {
            base.Start();

            float finalMass = airplaneWeight * poundsToKilos;

            if (rb)
            {
                rb.mass = finalMass;

                if (centerOfGravity)
                {
                    rb.centerOfMass = centerOfGravity.localPosition;
                }
            }
        }

        #endregion

        #region Costom Methods
        protected override void HandlePhysics()
        {
            HandleEngines();
            HandleAerodynamics();
            HandleSteering();
            HandleBrake();
            HandleAltitude();
        }

        void HandleEngines()
        {

        }

        void HandleAerodynamics()
        {

        }

        void HandleSteering()
        {

        }

        void HandleBrake()
        {

        }

        void HandleAltitude()
        {

        }
        #endregion
    }
}