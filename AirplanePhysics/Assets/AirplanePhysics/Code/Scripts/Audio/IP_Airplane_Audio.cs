using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_Airplane_Audio : MonoBehaviour 
    {
        #region Variables
        [Header("Airplane Audio Properties")]
        public IP_BaseAirplane_Input  input;
        public AudioSource idleSource;
        public AudioSource fullThrottleSource;
        public float maxPitchValue = 1.2f;

        private float finalVolumeValue;
        private float finalPitchValue;
        #endregion



        #region Builtin Methods
    	// Use this for initialization
    	void Start () 
        {
            if(fullThrottleSource)
            {
                fullThrottleSource.volume = 0f;
            }
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            if(input)
            {
                HandleAudio();
            }
    	}
        #endregion




        #region Custom Methods
        protected virtual void HandleAudio()
        {
            finalVolumeValue = Mathf.Lerp(0f, 1f, input.StickyThrottle);
            finalPitchValue = Mathf.Lerp(1f, maxPitchValue, input.StickyThrottle);

            if(fullThrottleSource)
            {
                fullThrottleSource.volume = finalVolumeValue;
                fullThrottleSource.pitch = finalPitchValue;
            }
        }
        #endregion
    }
}
