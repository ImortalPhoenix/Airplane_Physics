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

        [Header("Engines")]
        public List<Dr_Airplane_Engine> engines = new List<Dr_Airplane_Engine>();

        [Header("Wheels")]
        public List<Dr_Airplane_Wheel> wheels = new List<Dr_Airplane_Wheel>();
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

            if (wheels != null)
            {
                if(wheels.Count > 0)
                {
                    foreach(Dr_Airplane_Wheel wheel in wheels)
                    {
                        wheel.InitWheel();
                    }
                }
            }

        }

        #endregion

        #region Costom Methods
        protected override void HandlePhysics()
        {
            if (input)
            {
                HandleEngines();
                HandleAerodynamics();
                HandleSteering();
                HandleBrake();
                HandleAltitude();
            }   
        }

        void HandleEngines()
        {
            if(engines != null)
            {
                if(engines.Count > 0)
                {
                    foreach(Dr_Airplane_Engine engine in engines)
                    {
                        rb.AddForce(engine.CalculateForce(input.Throttle));
                    }
                }
            }
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