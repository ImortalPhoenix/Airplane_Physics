using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dragneel
{
    public class Dr_Airplane_Engine : MonoBehaviour
    {
        #region
        public float maxForce = 200f;
        public float maxRPM = 2550f;

        public AnimationCurve powerCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);
        #endregion

        #region Builtin methods
        #endregion

        #region Custom Methods
        public Vector3 CalculateForce(float throttle)
        {
            float finalThrottle = Mathf.Clamp01(throttle);
            finalThrottle = powerCurve.Evaluate(finalThrottle); 

            float finalPower = finalThrottle * maxForce;
            Vector3 finalForce = transform.TransformDirection(transform.forward) * finalPower;

            return finalForce;
        }

        #endregion
    }
}