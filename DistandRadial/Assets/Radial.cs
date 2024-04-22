using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Radial : MonoBehaviour
{
    [SerializeField]
    Transform enemyTF;
    [Range(0f, 5f)]
    public float radius;
    public bool isInside = false;

    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;

        if(isInside)
        {

        }


        Handles.color = isInside ? Color.green : Color.red; 
        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), radius);
    }
}
