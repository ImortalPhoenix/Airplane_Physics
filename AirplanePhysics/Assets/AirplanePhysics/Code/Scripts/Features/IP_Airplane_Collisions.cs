using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace IndiePixel
{
    public class IP_Airplane_Collisions : MonoBehaviour
    {
        public List<Vector3> hitPoints = new List<Vector3>();
        public List<Vector3> hitNormals = new List<Vector3>();

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.gameObject.name);

            for(int i = 0; i < collision.contacts.Length; i++)
            {
                //Debug.Log(collision.contacts[i].thisCollider.name);
                //Debug.Log(collision.contacts[i].point);

                hitPoints.Add(collision.contacts[i].point);
                hitNormals.Add(collision.contacts[i].normal);
            }
        }


        private void OnDrawGizmos()
        {
            if(hitPoints.Count > 0)
            {
                for(int i = 0; i < hitPoints.Count; i++)
                {
                    //Draw our Points
                    Gizmos.color = Color.magenta;
                    Gizmos.DrawSphere(hitPoints[i], 0.1f);

                    //Draw Normals
                    Gizmos.color = Color.green;
                    Gizmos.DrawRay(hitPoints[i], hitNormals[i]);
                }
            }
        }
    }
}
