using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Radial : MonoBehaviour
{
    [SerializeField]
    Transform enemyTF;
    [Range(0f, 5f)]
    public float radius;
    public bool isInside;
    public float Dist;

    private void OnDrawGizmos()
    {
        Vector2 origin = transform.position;

        //Dist = Vector3.Distance(origin, enemyTF.position);
        Dist = Mathf.Sqrt(origin.x * origin.x + enemyTF.position.x * enemyTF.position.x);

        isInside = Dist <= radius;

        Handles.color = isInside ? Color.green : Color.red; 
        Handles.DrawWireDisc(origin, new Vector3(0, 0, 1), radius);
    }
}
