using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Dragneel
{
    public static class Dr_Airplane_Menus
    {
        [MenuItem("Airplane Tools/Create new Airplane")]
        public static void CreateNewAirplane()
        {
            GameObject currentSelected = Selection.activeGameObject;
            if (currentSelected)
            {
                Dr_Airplane_Controller currentController = currentSelected.AddComponent<Dr_Airplane_Controller>();
                GameObject currentCOG = new GameObject("COG");
                currentCOG.transform.SetParent(currentSelected.transform);

                currentController.centerOfGravity = currentCOG.transform;     
            }

        } 
    }
}