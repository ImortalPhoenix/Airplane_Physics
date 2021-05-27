using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndiePixel
{
    public class IP_MobileAirplane_Input : IP_BaseAirplane_Input
    {
        #region Variables
        [Header("Mobile Input Properties")]
        public IP_Mobile_Thumbstick lThumbstick;
        public IP_Mobile_Thumbstick rThumbstick;
        #endregion


        #region Custom Methods
        protected override void HandleInput()
        {
            if(lThumbstick && rThumbstick)
            {
                //Process Main Control Input
                pitch = lThumbstick.VerticalAxis;
                roll = lThumbstick.HorizontalAxis;
                yaw = rThumbstick.HorizontalAxis;
                throttle = -rThumbstick.VerticalAxis;
            }
        }

        public void SetBrake(float aValue)
        {
            brake = aValue;
        }

        public void SetFlaps(int aValue)
        {
            flaps += aValue;
        }

        public void SetCamera(bool aFlag)
        {
            cameraSwitch = true;
        }
        #endregion
    }
}
