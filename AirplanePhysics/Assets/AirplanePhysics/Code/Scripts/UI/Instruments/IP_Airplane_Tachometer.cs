using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Airplane_Tachometer : MonoBehaviour, IAirplaneUI
    {

        #region Variables
        [Header("Tachometer Properties")]
        public IP_Airplane_Engine engine;
        public RectTransform pointer;
        public float maxRPM = 3500f;
        public float maxRotation = 312;
        public float pointerSpeed = 2f;

        private float finalRotation = 0f;
        #endregion



        #region Interface Methods
        public void HandleAirplaneUI()
        {
            if(engine && pointer)
            {
                float normalizedRPM = Mathf.InverseLerp(0f, maxRPM, engine.CurrentRPM);

                float wantedRotation = maxRotation * -normalizedRPM;
                finalRotation = Mathf.Lerp(finalRotation, wantedRotation, Time.deltaTime * pointerSpeed);
                pointer.rotation = Quaternion.Euler(0f, 0f, finalRotation);
            }
        }
        #endregion
    }
}
