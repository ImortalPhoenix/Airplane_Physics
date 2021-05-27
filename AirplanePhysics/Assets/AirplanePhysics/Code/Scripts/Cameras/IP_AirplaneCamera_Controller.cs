using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_AirplaneCamera_Controller : MonoBehaviour 
    {
        #region Variables
        [Header("Camera Controller Properties")]
        public IP_BaseAirplane_Input input;
        public int startCameraIndex = 0;
        public List<Camera> cameras = new List<Camera>();

        private int cameraIndex = 0;
        #endregion


        #region Builtin Methods
    	// Use this for initialization
    	void Start () 
        {
            if(startCameraIndex >= 0 && startCameraIndex < cameras.Count)
            {
                DisableAllCameras();
                cameras[startCameraIndex].enabled = true;
                cameras[startCameraIndex].GetComponent<AudioListener>().enabled = true;
            }
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            if(input)
            {
                if(input.CameraSwitch)
                {
                    SwitchCamera();
                }
            }
    	}
        #endregion



        #region Custom Methods
        protected virtual void SwitchCamera()
        {
            if(cameras.Count > 0)
            {
                DisableAllCameras();

                //Increment camera index
                cameraIndex++;

                //Warp Index
                if(cameraIndex >= cameras.Count)
                {
                    cameraIndex = 0;
                }

                cameras[cameraIndex].enabled = true;
                cameras[cameraIndex].GetComponent<AudioListener>().enabled = true;
            }

            input.CameraSwitch = false;
        }

        void DisableAllCameras()
        {
            if(cameras.Count > 0)
            {
                foreach(Camera cam in cameras)
                {
                    cam.enabled = false;
                    cam.GetComponent<AudioListener>().enabled = false;
                }
            }
        }
        #endregion
    }
}
