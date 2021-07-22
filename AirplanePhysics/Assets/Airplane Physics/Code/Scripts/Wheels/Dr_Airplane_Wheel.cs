using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dragneel
{
    [RequireComponent(typeof(WheelCollider))]
    public class Dr_Airplane_Wheel : MonoBehaviour
    {
        #region Variables
        private WheelCollider WheelCol;
        
        #endregion


        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
            WheelCol = GetComponent<WheelCollider>();
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Custom Methods
        public void InitWheel()
        {
            if (WheelCol)
            {
                WheelCol.motorTorque = 0.0000000001f;
            }
        }

        #endregion
    }
}