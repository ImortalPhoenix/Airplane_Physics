using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    public class IP_AirplaneThrottle_Physical : MonoBehaviour
    {
        #region Variables
        public float maxZOffset = -0.5f;
        public float sensitivity = 0.001f;
        public float smoothSpeed = 8f;

        private bool isHitting = false;
        private float wantedDelta;
        private Vector3 startPos;
        private Vector3 wantedPos;
        private Vector2 lastMousePosition;
        #endregion


        #region Builtin Methods
        // Use this for initialization
        void Start()
        {
            //Get the lever starting position
            startPos = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            HandleRaycast();
            HandleInteraction();
        }
        #endregion



        #region Custom Methods
        void HandleRaycast()
        {
            //Build a ray so we can see if we are hitting the lever
            Ray curRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Do our Raycast into the scene
            if(Physics.Raycast(curRay, out hit, 1000f))
            {
                if(hit.transform.GetInstanceID() == this.transform.GetInstanceID())
                {
                    //Debug.Log("Hitting the Lever!");
                    if(Input.GetMouseButtonDown(0))
                    {
                        //We are hitting so get the start mouse position
                        isHitting = true;
                        lastMousePosition = Input.mousePosition;
                    }
                }
            }
            
            //If we let go of the left mouse button then stop everything
            if(isHitting && Input.GetMouseButton(0) == false)
            {
                isHitting = false;
            }
        }

        void HandleInteraction()
        {
            if(isHitting)
            {
                //Calculate the delta for Z offset
                wantedDelta = (lastMousePosition.y - Input.mousePosition.y) * Time.deltaTime * sensitivity;
                startPos.z += wantedDelta;

                //make sure we dont go to far
                startPos.z = Mathf.Clamp(startPos.z, maxZOffset, 0f);
                wantedPos = startPos;

                //Get the New Mouse Position every frame while we are holding
                lastMousePosition = Input.mousePosition;
            }
            else
            {
                //Clear out the Delta value
                wantedDelta = 0f;
            }

            //Move the lever
            transform.position = Vector3.Lerp(transform.position, wantedPos, Time.deltaTime * smoothSpeed);
        }
        #endregion
    }
}
