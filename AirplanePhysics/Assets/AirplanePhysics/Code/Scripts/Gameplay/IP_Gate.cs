using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace IndiePixel
{
    [System.Serializable] public class FloatEvent : UnityEvent<float> { }
    public class IP_Gate : MonoBehaviour
    {
        #region Variables
        [Header("Gate Properties")]
        public bool reverseDirection = false;
        public bool isActive = false;

        [Header("UI Properties")]
        public Image arrowImage;

        [Header("Gate Events")]
        public FloatEvent OnClearedGate = new FloatEvent();
        public UnityEvent OnFailedGate = new UnityEvent();

        private Vector3 gateDirection;
        private bool isCleared = false;
        #endregion

        #region Builtin Methods
        // Use this for initialization
        void Start()
        {
            GetGateDirection();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player" && !isCleared)
            {
                float dist = Vector3.Distance(other.transform.position, transform.position);
                float distPercentage = dist / transform.localScale.x;

                CheckDirection(other.transform.forward, distPercentage);
            }
        }

        private void OnDrawGizmos()
        {
            GetGateDirection();

            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, transform.position + gateDirection * 6f);
            Gizmos.DrawSphere(transform.position + gateDirection * 6f, 1f);
        }
        #endregion


        #region Custom Methods
        public void ActivateGate()
        {
            isActive = true;

            if (arrowImage)
            {
                arrowImage.enabled = true;
            }
        }

        public void DeactivateGate()
        {
            isActive = false;

            if(arrowImage)
            {
                arrowImage.enabled = false;
            }
        }

        void CheckDirection(Vector3 direction, float distPercentage)
        {
            float dotValue = Vector3.Dot(gateDirection, direction);
            if (dotValue > 0.25f)
            {
                isCleared = true;
                if(OnClearedGate != null)
                {
                    OnClearedGate.Invoke(distPercentage);
                }

                DeactivateGate();
            }
            else
            {
                //Debug.Log("Player Failed the Gate");
                if(OnFailedGate != null)
                {
                    OnFailedGate.Invoke();
                }
            }
        }

        void GetGateDirection()
        {
            gateDirection = transform.forward;
            if (reverseDirection)
            {
                gateDirection = -gateDirection;
            }
        }
        #endregion
    }
}
