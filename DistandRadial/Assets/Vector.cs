using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector : MonoBehaviour
{
    public Transform ATransform;
    public Transform BTransform;

    public float Dist;
    private void OnDrawGizmos()
   {
        Vector2 aTrans = ATransform.position;
        Vector2 bTrans = BTransform.position;

        Gizmos.color = Color.yellow;
        //Dist = Vector2.Distance(aTrans, bTrans);
        //Dist = (aTrans - bTrans).magnitude;
        Dist = Mathf.Sqrt(aTrans.x * aTrans.x + bTrans.x * bTrans.x);
        Gizmos.DrawLine(aTrans, bTrans);
    }
}
