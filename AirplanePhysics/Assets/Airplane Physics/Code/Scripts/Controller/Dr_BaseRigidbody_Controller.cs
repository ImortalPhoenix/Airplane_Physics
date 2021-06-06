﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dragneel
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class Dr_BaseRigidbody_Controller : MonoBehaviour
    {

        #region Variables
        protected Rigidbody rb;
        protected AudioSource aSource;

        #endregion

        #region Bultin Methods

        // Start is called before the first frame update
        public virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
            aSource = GetComponent<AudioSource>();
            if (aSource)
            {
                aSource.playOnAwake = false;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (rb)
            {
                HandlePhysics();

            }
        }
        #endregion


        #region Custom Methods
        //created costom methods
        protected virtual void HandlePhysics()
        {

        }

        #endregion
    }
}