using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace IndiePixel
{
    [CustomEditor(typeof(IP_Airplane_ControlSurface))]
    public class IP_Airplane_ControlSurface_Editor : Editor
    {
        #region Variables
        IP_Airplane_ControlSurface targetControlSurface;
        #endregion

        #region BuiltIn Methods
        private void OnEnable()
        {
            targetControlSurface = (IP_Airplane_ControlSurface)target;
        }

        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();

            //Get all the Properites in the script
            var so = new SerializedObject(targetControlSurface);
            var curArray = so.FindProperty("flaps");
            var type = so.FindProperty("type");
            var maxAngle = so.FindProperty("maxAngle");
            var axis = so.FindProperty("axis");
            var graphics = so.FindProperty("controlSurfaceGraphic");
            var smoothSpeed = so.FindProperty("smoothSpeed");
            
            //Update the serilized object
            so.Update();

            //Display the Properties
            EditorGUILayout.PropertyField(type);
            EditorGUILayout.PropertyField(maxAngle);
            EditorGUILayout.PropertyField(axis);
            EditorGUILayout.PropertyField(graphics);
            EditorGUILayout.PropertyField(smoothSpeed);

            //Show the Flaps array only when type is set to "Flaps"
            if (targetControlSurface.type == ControlSurfaceType.Flap)
            {
                EditorGUILayout.Space();
                EditorGUILayout.PropertyField(curArray, true);
            }
            //Mak sure to apply any changes made
            so.ApplyModifiedProperties();

            //Update the Editor
            Repaint();
        }
        #endregion
    }
}
