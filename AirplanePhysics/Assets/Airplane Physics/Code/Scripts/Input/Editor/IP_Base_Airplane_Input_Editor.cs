using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Dragneel
{
    [CustomEditor(typeof(IP_Base_Airplane_Input))]
    public class IP_Base_Airplane_Input_Editor : Editor
    {
        #region Variables
        private IP_Base_Airplane_Input targetInput;

        #endregion



        #region Bultin Methods
        private void OnEnable()
        {
            targetInput = (IP_Base_Airplane_Input)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            string debugInfo = "";
            debugInfo += "Pitch = " + targetInput.Pitch + "\n";
            debugInfo += "Roll = " + targetInput.Roll + "\n";
            debugInfo += "Yaw = " + targetInput.Yaw + "\n";
            debugInfo += "Throttle = " + targetInput.Throttle + "\n";
            debugInfo += "Flaps = " + targetInput.Flaps + "\n";
            debugInfo += "Brake = " + targetInput.Brake + "\n";



            //Custom Editor Code
            GUILayout.Space(20);
            EditorGUILayout.TextArea( debugInfo ,GUILayout.Height(100));

            Repaint();

        }
        #endregion
        
    }
}