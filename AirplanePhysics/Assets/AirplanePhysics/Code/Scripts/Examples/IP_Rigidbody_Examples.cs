using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IndiePixel
{
    [RequireComponent(typeof(Rigidbody))]
    public class IP_Rigidbody_Examples : MonoBehaviour 
    {
        #region Variables
        private Rigidbody rb;
        #endregion


        #region Builtin Methods
    	// Use this for initialization
    	void Start () 
        {
            rb = GetComponent<Rigidbody>();
    	}
    	
    	// Update is called once per frame
    	void FixedUpdate () 
        {
            if(rb)
            {
                Vector3 wantedForce = transform.up * (rb.mass * Physics.gravity.magnitude);
                rb.AddForce(wantedForce);
                Debug.DrawRay(transform.position, wantedForce, Color.green);
            }
    	}
        #endregion
    }
}
