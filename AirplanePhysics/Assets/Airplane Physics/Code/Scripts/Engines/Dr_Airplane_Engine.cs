using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dragneel
{
    public class Dr_Airplane_Engine : MonoBehaviour
    {
        #region

        [Header("Engine Properties")]
        public float maxForce = 200f;
        public float maxRPM = 2550f;

        public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        
        [Header("Propeller")]
        public Dr_Airplane_Propeller propeller;  
        
        #endregion




        #region Builtin methods
        #endregion

        #region Custom Methods
        public Vector3 CalculateForce(float throttle)
        {
            //Calculate Power
            float finalThrottle = Mathf.Clamp01(throttle);
            finalThrottle = powerCurve.Evaluate(finalThrottle);

            float currentRPM = finalThrottle * maxRPM;

            // calculate RPM;
            if (propeller)
            {
                propeller.HandlePropeller(currentRPM);
            }

            float finalPower = finalThrottle * maxForce;
            Vector3 finalForce = transform.TransformDirection(transform.forward) * finalPower;

            return finalForce;
        }

        #endregion
    }
}