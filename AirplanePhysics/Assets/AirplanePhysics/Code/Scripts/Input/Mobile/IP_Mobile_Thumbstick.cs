using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace IndiePixel
{
    public class IP_Mobile_Thumbstick : MonoBehaviour
    {
        #region Variables
        [Header("Thumbstick Properties")]
        public bool useMouse = true;
        public RectTransform knob;
        public float dragSpeed = 30f;
        public float resetSpeed = 20f;

        private RectTransform bounds;
        private Vector2 finalDelta;
        private bool isTouching;
        #endregion


        #region Properties
        public float VerticalAxis
        {
            get { return finalDelta.y; }
        }

        public float HorizontalAxis
        {
            get { return finalDelta.x; }
        }
        #endregion



        #region Main Methods
        // Use this for initialization
        void Start()
        {
            bounds = GetComponent<RectTransform>();
        }

        // Update is called once per frame
        void Update()
        {
            if(bounds && knob)
            {
                HandleThumbstick();
            }
        }
        #endregion


        #region Custom Methods
        void HandleThumbstick()
        {
            if(!isTouching)
            {
                isTouching = RectTransformUtility.RectangleContainsScreenPoint(bounds, Input.mousePosition);
            }

            if(useMouse)
            {
                HandleMouse();
            }
            else
            {
                HandleTouches();
            }
        }

        void HandleMouse()
        {
            if(Input.GetMouseButton(0))
            {
                if(isTouching)
                {
                    HandleDragging();
                }
            }
            else
            {
                isTouching = false;
                ResetKnob();
            }
        }

        void HandleTouches()
        {

        }

        protected virtual void HandleDragging()
        {
            //Get the target position for the knob
            Vector2 wantedPosition = Vector2.zero;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(bounds, Input.mousePosition, null, out wantedPosition);
            knob.anchoredPosition = Vector2.Lerp(knob.anchoredPosition, wantedPosition, Time.deltaTime * dragSpeed);

            //Find the normalized Delta for the Knob
            float xDelta = knob.anchoredPosition.x / (bounds.rect.width * 0.5f);
            float yDelta = knob.anchoredPosition.y / (bounds.rect.height * 0.5f);
            finalDelta = new Vector2(xDelta, yDelta);
            finalDelta = Vector2.ClampMagnitude(finalDelta, 1f);
        }

        void ResetKnob()
        {
            knob.anchoredPosition = Vector2.Lerp(knob.anchoredPosition, Vector2.zero, Time.deltaTime * resetSpeed);
            finalDelta = Vector2.zero;
        }
        #endregion
    }
}
