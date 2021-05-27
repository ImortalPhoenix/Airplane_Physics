using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace IndiePixel
{
    public class IP_AirplaneUI_Controller : MonoBehaviour 
    {
        #region Variables
        public List<IAirplaneUI> instruments = new List<IAirplaneUI>();
        #endregion


        #region Builtin Methods
    	// Use this for initialization
    	void Start () 
        {
            instruments = transform.GetComponentsInChildren<IAirplaneUI>().ToList<IAirplaneUI>();
    	}
    	
    	// Update is called once per frame
    	void Update () 
        {
            if(instruments.Count > 0)
            {
                foreach(IAirplaneUI instrument in instruments)
                {
                    instrument.HandleAirplaneUI();
                }
            }
    	}
        #endregion
    }
}
