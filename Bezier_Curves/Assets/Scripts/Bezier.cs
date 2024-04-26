using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode, RequireComponent (typeof(LineRenderer))]
public class Bezier : MonoBehaviour
{
    public Transform p0, p1, p2;
    [Range(0,10)]
    public float Width;
    [Range(0,1)]
    public float _discSize = 0.15f;
    [Range(0,1)]
    public float lineWidth;
    public Color circle, midCircle, midFill, midConnector, bezier;
    [Range(0, 1)]
    public float t = 0;
    public int points = 20;
    public LineRenderer line;

    public Material mat;
    public Vector3 _2DSpace = new Vector3(0, 0, 1);

    public static Bezier Instance { get; private set; }
    public Vector3 targetPostion { get { return m_target; } set { m_target = value; } }
    private Vector3 m_target = new Vector3(1, 0, 3);
    private void OnDrawGizmos()
    {
        Handles.color = circle;
        Handles.DrawSolidDisc(p0.position, _2DSpace, _discSize);
        Handles.DrawSolidDisc(p1.position, _2DSpace, _discSize);
        Handles.DrawSolidDisc(p2.position, _2DSpace, _discSize);

        Handles.color = Color.white;
        Handles.DrawDottedLine(p0.position, p1.position, 5f);
        Handles.DrawDottedLine(p1.position, p2.position, 5f);

        Vector3 p0top1 = Linear(p0.position, p1.position);
        Vector3 p1top2 = Linear(p1.position, p2.position);

        Handles.color = midFill;
        Handles.DrawLine(p0.position, p0top1, Width);
        Handles.DrawLine(p1.position, p1top2, Width);
        Handles.color = midCircle;
        Handles.DrawSolidDisc(p0top1, _2DSpace, _discSize);
        Handles.DrawSolidDisc(p1top2, _2DSpace, _discSize);

        Handles.color = midConnector;
        Handles.DrawLine(p0top1, p1top2, Width);

        Vector3 mid = Linear(p0top1, p1top2);
        Handles.DrawSolidDisc(mid, _2DSpace, _discSize);
    }
   
    public virtual void Update()
    {
        if (points > 0)
        {
            line.positionCount = points;
        }

        mat.SetColor("_Color", bezier);
        Vector3 pos;
        for (int i = 0; i < points; i++)
        {
            float _t = i / (points - 1.0f);
            pos = (1.0f - _t) * (1.0f - _t) * p0.position + 2.0f * (1.0f - _t) * _t * p1.position + _t * _t * p2.position;
            line.startWidth = lineWidth;
            line.endWidth = lineWidth;
            line.SetPosition(i, pos);
        }
    }

    public Vector3 Linear(Vector3 p0, Vector3 p1)
    {
        Vector3 linear = (1 - t) * p0 + t * p1;
        return linear;
    }
}
