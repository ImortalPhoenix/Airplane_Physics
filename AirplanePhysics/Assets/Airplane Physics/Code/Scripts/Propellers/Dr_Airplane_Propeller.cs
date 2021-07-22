using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Dragneel
{
    public class Dr_Airplane_Propeller : MonoBehaviour
    {
        #region Variables
        [Header("Propeller Properties")]
        public float minQuadRPMs = 300f;
        public float minTextureSwap = 600f;

        public GameObject mainProp;
        public GameObject blurredProp;

        [Header("Material Properties")]
        public Material blurredPropMat;
        public Texture2D blurLevel1;
        public Texture2D blurLevel2;
        #endregion


        #region Builtin Methods
        // Start is called before the first frame update
        void Start()
        {
            if (mainProp && blurredProp)
            {
                HandleSwapping(0f);
            }
        }



        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Custom Methods
        public void HandlePropeller(float currentRPM)
        {
            // get our degrees per second
            float dps = ((currentRPM * 360f) / 60f) * Time.deltaTime;
            
            //Rotate the propeller Group
            transform.Rotate(Vector3.forward, dps);

            //Handle Propellers
            if (mainProp && blurredProp)
            {
                HandleSwapping(currentRPM);
            }
        }
        void HandleSwapping(float currentRPM)
        {
            if(currentRPM > minQuadRPMs)
            {
                blurredProp.gameObject.SetActive(true);
                mainProp.gameObject.SetActive(false);

                if (blurredPropMat && blurLevel1 && blurLevel2)
                {
                    if (currentRPM > minTextureSwap)
                    {
                        blurredPropMat.SetTexture("_MainTex", blurLevel2);
                    }
                    else
                    {
                        blurredPropMat.SetTexture("_MainTex", blurLevel1);
                    }
                }
                
            }
            else
            {
                blurredProp.gameObject.SetActive(false);
                mainProp.gameObject.SetActive(true);
            }
        }

        #endregion

    }
}